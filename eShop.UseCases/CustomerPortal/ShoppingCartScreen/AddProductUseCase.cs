using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public AddProductUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task ExecuteAsync(Product product)
        {
            await _shoppingCart.AddProductAsync(product);
        }
    }
}
