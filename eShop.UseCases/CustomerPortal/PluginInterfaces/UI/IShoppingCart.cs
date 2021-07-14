using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        Task<Order> AddProductAsync(Product product);
        Task<Order> DeleteProductAsync(int product);
        Task EmptyAsync();
        Task GetOrderAsync();
        Task<Order> PlaceOrderAsync();
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> UpdateQuantityAsync(int productId, int quantity);
    }
}
