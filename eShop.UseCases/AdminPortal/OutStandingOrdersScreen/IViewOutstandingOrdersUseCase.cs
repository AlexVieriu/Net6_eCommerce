namespace eShop.UseCases.AdminPortal.OutStandingOrdersScreen;

public interface IViewOutstandingOrdersUseCase
{
    IEnumerable<Order> Execute();
}
