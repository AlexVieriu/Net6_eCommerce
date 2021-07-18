using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.ShoppingCartLocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string constShoppingCart = "eShop.localStorage";

        private readonly IJSRuntime _jSRuntime;
        private readonly IProductRepository _productRepo;

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepo)
        {
            _jSRuntime = jSRuntime;
            _productRepo = productRepo;
        }

        public async Task<Order> AddProductToCartAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price, product);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public async Task EmptyAsync()
        {
            await SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int qty)
        {
            var order = await GetOrder();
            if (qty < 0)
                return order;
            if (qty == 1)
                await DeleteProductAsync(productId);

            var lineItem = order.LineItems.FirstOrDefault(x => x.ProductId == productId);
            if(lineItem != null)
                lineItem.Quantity = qty;

            await SetOrder(order);

            return order;                
        }

        private async Task<Order> GetOrder()
        {
            Order order;
            var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", constShoppingCart);
            if (string.IsNullOrWhiteSpace(strOrder) || strOrder.ToLower() == "null")
            {
                order = new();
                await SetOrder(order);
            }
            else 
                order = JsonConvert.DeserializeObject<Order>(strOrder);

            //foreach (var item in order.LineItems)
            //{
            //    item.Product = _productRepo.GetProduct(item.ProductId);
            //}

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem",
                                                    constShoppingCart,
                                                    JsonConvert.SerializeObject(order));
        }
    }
}
