using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.Services;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;
using eShop.UseCases.CustomerPortal.PluginInterfaces.StateStore;
using eShop.UseCases.CustomerPortal.PluginInterfaces.UI;
using eShop.UseCases.CustomerPortal.ShoppingCartScreen.Interfaces;
using System;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _stateStore;

        public PlaceOrderUseCase(IOrderService orderService,
                                 IOrderRepository orderRepository,
                                 IShoppingCart shoppingCart,
                                 IShoppingCartStateStore stateStore)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _stateStore = stateStore;
        }

        public async Task<string> ExecuteAsync(Order order)
        {
            if(_orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqueId = Guid.NewGuid().ToString();
                _orderRepository.CreateOrder(order);

                await _shoppingCart.EmptyCartAsync();
                _stateStore.BroadCastState();

                return order.UniqueId;
            }

            return null;
        }
    }
}
