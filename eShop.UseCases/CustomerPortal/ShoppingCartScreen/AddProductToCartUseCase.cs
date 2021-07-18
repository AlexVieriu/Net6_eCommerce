using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public AddProductToCartUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public void Execute(Product product)
        {
            _shoppingCart.AddProductToCartAsync(product);
        }
    }
}
