using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        // AddProductToCartAsync
        Task<Order> AddProductToCartAsync(Product product);

        // DeleteProductAsync
        Task<Order> DeleteProductAsync(int productId);
        
        // EmptyAsync
        Task EmptyAsync();

        // GetOrderAsync
        Task<Order> GetOrderAsync();

        // UpdateOrderAsync
        Task<Order> UpdateOrderAsync(Order order);
        
        // UpdateQuantityAsync
        Task<Order> UpdateQuantityAsync(int productId, int qty);

    }
}
