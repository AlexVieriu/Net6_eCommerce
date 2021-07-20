using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.StateStore;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using System.Threading.Tasks;

namespace eShop.StateStore.DI
{
    public class StateStoreShoppingCart : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart _shoppingCart;

        public StateStoreShoppingCart(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<int> GetItemsCount()
        {
            Order order;
            order = await _shoppingCart.GetOrderAsync();

            if (order.LineItems.Count > 0)
                return order.LineItems.Count;

            return 0;
        }
    }
}
