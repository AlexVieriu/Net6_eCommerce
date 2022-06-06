namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;

public interface IUpdateQuantityUseCase
{
    Task<Order> ExecuteAsync(int productId, int qty);
}
