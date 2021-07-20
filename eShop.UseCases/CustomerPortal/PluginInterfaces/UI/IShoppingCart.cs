using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        // AddProductToCart
        void AddProductToCartAsync(Product product);

        // RemoveProductFromCartAsync
        Task<Order> DeleteProductFromCartAsync(int productId);

        // EmptyCartAsync
        void EmptyCartAsync();

        // GetOrderAsync
        Task<Order> GetOrderAsync();

        // UpdateOrderAsync
        void UpdateOrderAsync(Order order);

        // UpdateQuantityAsync
        Task<Order> UpdateQuantityAsync(int productId, int quantity);

    }
}
