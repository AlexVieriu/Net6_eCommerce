namespace eShop.UseCases.AdminPortal.OutStandingOrdersScreen;

public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
{
    private readonly IOrderRepository _orderRepository;

    public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public IEnumerable<Order> Execute()
    {
        var orders = _orderRepository.GetOutstandingsOrders();
        
        return orders;
    }
}
