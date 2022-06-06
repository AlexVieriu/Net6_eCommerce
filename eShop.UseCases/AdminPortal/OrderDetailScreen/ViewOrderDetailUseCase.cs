namespace eShop.UseCases.AdminPortal.OrderDetailScreen;

public class ViewOrderDetailUseCase : IViewOrderDetailUseCase
{
    private readonly IOrderRepository _orderRepository;

    public ViewOrderDetailUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order Execute(int orderId)
    {
        var order = _orderRepository.GetOrder(orderId);

        return order;
    }
}
