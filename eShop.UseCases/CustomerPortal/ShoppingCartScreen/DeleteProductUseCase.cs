using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public DeleteProductUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<Order> ExecuteAsync(int productId)
        {
            var order = await _shoppingCart.DeleteProductFromCartAsync(productId);

            return order;
        }
    }
}
