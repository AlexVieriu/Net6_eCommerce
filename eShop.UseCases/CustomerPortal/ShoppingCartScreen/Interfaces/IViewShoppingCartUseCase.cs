namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;

public interface IViewShoppingCartUseCase
{
    Task<Order> ExecuteAsync();
}
