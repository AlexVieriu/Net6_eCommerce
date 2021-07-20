using eShop.CoreBusiness.Models;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces
{
    public interface IAddProductToCartUseCase
    {
        void Execute(Product product);
    }
}
