using eShop.CoreBusiness.Models;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces
{
    public interface IUpdateProductUseCase
    {
        Task<Order> ExecuteAsync(int productId, int qty);
    }
}
