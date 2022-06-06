﻿namespace eShop.UseCases.AdminPortal.ProcessedOrdersScreen;

public class ViewProcessedOrdersUseCase : IViewProcessedOrdersUseCase
{
    private readonly IOrderRepository _orderRepository;

    public ViewProcessedOrdersUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<Order> Execute()
    {
        var orders = _orderRepository.GetProcessedOrders();

        return orders;
    }
}
