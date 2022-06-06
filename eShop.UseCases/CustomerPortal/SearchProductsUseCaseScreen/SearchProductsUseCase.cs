namespace eShop.UseCases.CustomerPortal.SearchProductsUseCaseScreen;

public class SearchProductsUseCase : ISearchProductsUseCase
{
    private readonly IProductRepository _productRepository;

    public SearchProductsUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> Execute(string filter = null)
    {
        var productList = _productRepository.GetProducts(filter);

        return productList;
    }
}


