namespace eShop.UseCases.CustomerPortal.SearchProductsUseCaseScreen;

public interface ISearchProductsUseCase
{
    List<Product> Execute(string filter = null);
}