namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen;

public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IShoppingCart _shoppingCart;
    private readonly IShoppingCartStateStore _stateStore;

    public DeleteProductUseCase(IShoppingCart shoppingCart,
                                IShoppingCartStateStore stateStore)
    {
        _shoppingCart = shoppingCart;
        _stateStore = stateStore;
    }

    public async Task<Order> ExecuteAsync(int productId)
    {
        var order = await _shoppingCart.DeleteProductFromCartAsync(productId);
        _stateStore.BroadCastState();

        return order;
    }
}
