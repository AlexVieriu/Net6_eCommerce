using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;
using System.Collections.Generic;

namespace eShop.UseCases.CustomerPortal.SearchProductsUseCaseScreen
{
    public class SearchProductsUseCase : ISearchProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public SearchProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> Execute(string filter = null)
        {
            return _productRepository.GetProducts(filter);
        }
    }


}
