using eShop.CoreBusiness.Models;
using System.Collections.Generic;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore
{
    public interface IProductRepository
    {
        Product GetProduct(int productId);
        List<Product> GetProducts(string filter = null);
    }
}
