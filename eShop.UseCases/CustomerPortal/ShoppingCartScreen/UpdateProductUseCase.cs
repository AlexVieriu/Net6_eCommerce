using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IShoppingCart _shoppingCart;

        public UpdateProductUseCase(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<Order> ExecuteAsync(int productId, int qty)
        {
            var order = await _shoppingCart.UpdateQuantityAsync(productId, qty);

            return order;
        }
    }
}
