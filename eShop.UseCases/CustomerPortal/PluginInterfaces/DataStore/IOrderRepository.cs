using eShop.CoreBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore
{
    public interface IOrderRepository
    {
        // CreateOrder - return uniquedId
        int CreateOrder(Order order);

        // GetOrder() - return Order
        Order GetOrder(int orderId);

        // GetOrderByUniqueId() - return order
        Order GetOrderByUniqueId(string uniqueId);

        // GetOrders()  - return orders
        IEnumerable<Order> GetOrders();

        // GetOutstandingsOrders() - return orders (dataProcessed = false)
        IEnumerable<Order> GetOutstandingsOrders();

        // GetProcessedOrders() - return orders (dataProcessed = true)
        IEnumerable<Order> GetProcessedOrders();

        // UpdateOrder() - void 
        void UpdateOrder(Order order);
    }
}
