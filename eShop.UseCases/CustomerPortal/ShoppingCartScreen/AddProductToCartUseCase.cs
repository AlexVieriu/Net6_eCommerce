namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen;

public class AddProductToCartUseCase : IAddProductToCartUseCase
{
    private readonly IShoppingCart _shoppingCart;
    private readonly IShoppingCartStateStore _stateStore;

    public AddProductToCartUseCase(IShoppingCart shoppingCart,
                                   IShoppingCartStateStore stateStore)
    {
        _shoppingCart = shoppingCart;
        _stateStore = stateStore;
    }

    public async void Execute(Product product)
    {
        await _shoppingCart.AddProductToCartAsync(product);
        _stateStore.BroadCastState();
    }
}
