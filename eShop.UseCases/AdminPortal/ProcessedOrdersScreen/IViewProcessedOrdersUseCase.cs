namespace eShop.UseCases.AdminPortal.ProcessedOrdersScreen;

public interface IViewProcessedOrdersUseCase
{
    IEnumerable<Order> Execute();
}
