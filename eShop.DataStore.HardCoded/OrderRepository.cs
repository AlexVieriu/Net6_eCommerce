using eShop.CoreBusiness.Models;
using eShop.UseCases.CustomerPortal.PluginInterfaces.DataStore;
using System.Collections.Generic;
using System.Linq;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> Orders;

        public OrderRepository()
        {
            Orders = new();
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = Orders.Count + 1;
            Orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public Order GetOrder(int orderId)
        {
            return Orders[orderId];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            var order = Orders.Values.FirstOrDefault(q => q.UniqueId == uniqueId);

            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return Orders.Values;
        }

        public IEnumerable<Order> GetOutstandingsOrders()
        {
            var orders = Orders.Values.Where(q => q.DateProcessed.HasValue == false);
            return orders;
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var orders = Orders.Values.Where(q => q.DateProcessed.HasValue == true);
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            if (order != null && order.LineItems != null && order.LineItems.Count > 0)
                Orders[order.OrderId.Value] = order;
            
            return;
        }
    }
}
