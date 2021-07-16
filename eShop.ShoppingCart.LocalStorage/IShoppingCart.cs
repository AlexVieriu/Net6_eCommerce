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
        private const string cstrShoppingCart = "eShop.ShoppingCart";

        private readonly IJSRuntime _jSRuntime;
        private readonly IProductRepository _productRepo;

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepo)
        {
            _jSRuntime = jSRuntime;
            _productRepo = productRepo;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            // GetOrder
            var order = await GetOrder();

            // AddProduct
            order.AddProduct(product.ProductId, 1, product.Price, product); // Added product

            // SetOrder
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            // GetOrder
            var order = await GetOrder();

            // RemoveProduct
            order.RemoveProduct(productId);

            // SetOrder 
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
            if (qty == 0)
                await DeleteProductAsync(productId);

            var item = order.LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
                item.Quantity = qty;

            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order;
            var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                if (item.Product == null)
                    item.Product = _productRepo.GetProduct(item.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem",
                                             cstrShoppingCart,
                                             JsonConvert.SerializeObject(order));
        }
    }
}
