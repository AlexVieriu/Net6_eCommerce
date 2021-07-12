using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCreateOrder(Order order)
        {
            // Order exist
            if (order == null) return false;

            // LineOrder exists, LineOrders.Count > 0
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            // ProductId, Qty, Price from LineOrder must be > 0
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Quantity <= 0 ||
                    item.Price <= 0)
                    return false;
            }

            // ValidateCustomerInformation()
            if (!ValidateCustomerInformation(order.CustomerName,
                                            order.CustomerAddress,
                                            order.CustomerCity,
                                            order.CustomerStateProvince,
                                            order.CustomerCountry))
                return false;

            return true;
        }

        public bool ValidateCustomerInformation(string name, string address, string city, string province, string country)
        {
            if (!string.IsNullOrWhiteSpace(name) ||
                !string.IsNullOrWhiteSpace(address) ||
                !string.IsNullOrWhiteSpace(city) ||
                !string.IsNullOrWhiteSpace(province) ||
                !string.IsNullOrWhiteSpace(country))
                return false;

            return true;
        }

        public bool ValidateProcessOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateUpdateOrder(Order order)
        {
            // has Order
            if (order == null) return false;

            // has OrderId
            if (order.OrderId < 1) return false;

            // has LineItems, LineItems.Count >0 
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;

            // has ProductId, Qty, Price > 0 for LineItems
            foreach (var item in order.LineItems)
            {
                if (item.Quantity <= 0 ||
                    item.Price <= 0 ||
                    item.ProductId <= 0)
                    return false;
            }

            // !DataProccesed.HasValue, DataProccesing.HasValue
            if (!order.DateProcessed.HasValue || order.DateProcessing.HasValue) return false;

            // UniqueId
            if (string.IsNullOrWhiteSpace(order.UniqueId)) return false;

            // Validate Customer Information
            if (!ValidateCustomerInformation(order.CustomerName,
                                          order.CustomerAddress,
                                          order.CustomerCity,
                                          order.CustomerStateProvince,
                                          order.CustomerCountry))
                return false;

            return true;
        }
    }
}
