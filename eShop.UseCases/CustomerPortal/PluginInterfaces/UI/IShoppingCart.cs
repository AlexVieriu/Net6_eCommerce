namespace eShop.UseCases.CustomerPortal.PluginInterfaces.UI;

public interface IShoppingCart
{
    Task AddProductToCartAsync(Product product);
    Task<Order> DeleteProductFromCartAsync(int productId);
    Task EmptyCartAsync();
    Task<Order> GetOrderAsync();
    Task UpdateOrderAsync(Order order);
    Task<Order> UpdateQuantityAsync(int productId, int quantity);

}
