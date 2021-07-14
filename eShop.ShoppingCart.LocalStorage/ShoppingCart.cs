using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string constShoppingCart = "eShop.ShoppingCart";

        private readonly IJSRuntime _jSRuntime;
        private readonly IProductRepository _productRepository;

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepository)
        {
            _jSRuntime = jSRuntime;
            _productRepository = productRepository;
        }

        public Task<Order> AddProductAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> DeleteProductAsync(int product)
        {
            throw new System.NotImplementedException();
        }

        public Task EmptyAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task GetOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            throw new System.NotImplementedException();
        }

        private async Task<Order> GetOrder()
        {
            Order order;
            // get the Order
            var orderStr = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", constShoppingCart);
            if (string.IsNullOrWhiteSpace(orderStr))
            {
                order = new Order();
                await SetOrder(order);
            }
            else
                order = JsonConvert.DeserializeObject<Order>(orderStr);

            // get LineItems 
            foreach (var item in order.LineItems)
            {
                item.Product = _productRepository.GetProduct(item.ProductId);
            }

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
