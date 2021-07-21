using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShopingCartBase : IShoppingCart
    {
        private const string _constShoppingCart = "eShop.LocalStorage";

        private readonly IJSRuntime _jSRuntime;

        public ShopingCartBase(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async void AddProductToCartAsync(Product product)
        {
            // GetOrder
            var order = await GetOrder();

            // AddProduct
            order.AddProduct(product.ProductId, 1, product.Price, product);

            // SetOrder
            await SetOrder(order);
        }

        public async Task<Order> DeleteProductFromCartAsync(int productId)
        {
            // GetOrder
            var order = await GetOrder();

            // RemoveProduct
            order.RemoveProduct(productId);

            // SetOrder
            await SetOrder(order);

            return order;
        }

        public async Task EmptyCartAsync()
        {
            await SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public async void UpdateOrderAsync(Order order)
        {
            await SetOrder(order);
        }

        // DE REVAZUT!!
        public async Task<Order> UpdateQuantityAsync(int productId, int qty)
        {
            // Get Order
            var order = await GetOrder();
            if (qty < 0)
                return order;

            else if (qty == 0)
                order = await DeleteProductFromCartAsync(productId);

            else
            {
                var lineItem = order.LineItems.FirstOrDefault(x => x.ProductId == productId);
                if (lineItem != null)
                    lineItem.Quantity = qty;
            }

            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order;
            var strOrder = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", _constShoppingCart);
            if (strOrder == null)
            {
                order = new();
                await SetOrder(order);
            }
            else
                order = JsonConvert.DeserializeObject<Order>(strOrder);

            // add Product to ListItems

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem",
                                             _constShoppingCart,
                                             JsonConvert.SerializeObject(order));
        }
    }
}
