using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        // GetOrderAsync
        Task<Order> GetOrderAsync();

        // AddProductAsync
        Task<Order> AddProductAsync(Product product);

        // DeleteProductAsync
        Task<Order> DeleteProductAsync(int productId);

        // EmptyAsync --- cand se foloseste
        Task EmptyAsync();

        // UpdateOrderAsync
        Task<Order> UpdateOrderAsync(Order order);

        // UpdateQuantityAsync
        Task<Order> UpdateQuantityAsync(int productId, int qty);
                      
    }
}
