using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;

namespace eShop.UseCases.CustomerPortal.ViewProductUseCaseScreen
{
    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(int productId)
        {
            var product= _productRepository.GetProduct(productId);

            return product;
        }
    }
}
