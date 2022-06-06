namespace eShop.CoreBusiness.Services;

public class OrderService : IOrderService
{

    public bool ValidateCreateOrder(Order order)
    {
        // order is null
        if (order == null)
            return false;

        // line item are null and <=0
        if (order.LineItems == null || order.LineItems.Count <= 0)
            return false;

        // price, qty , productId < 0
        foreach (var item in order.LineItems)
        {
            if (item.ProductId < 0 ||
                item.Quantity < 0 ||
                item.Price < 0)
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

    public bool ValidateCustomerInformation(string name,
                                            string address,
                                            string city,
                                            string stateprovince,
                                            string country)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(address) ||
            string.IsNullOrWhiteSpace(city) ||
            string.IsNullOrWhiteSpace(stateprovince) ||
            string.IsNullOrWhiteSpace(country))
            return false;

        return true;
    }

    public bool ValidateProcessOrder(Order order)
    {
        if (!order.DateProcessed.HasValue || string.IsNullOrWhiteSpace(order.AdminUser)) // ??
            return false;

        return true;
    }

    public bool ValidateUpdateOrder(Order order)
    {
        // order is null 
        if (order == null)
            return false;

        // order id <0
        if (order.OrderId < 0)
            return false;

        // line items is null  and <= 0
        if (order.LineItems == null || order.LineItems.Count <= 0)
            return false;


        // qty, producid, price<0
        foreach (var item in order.LineItems)
        {
            if (item.ProductId < 0 ||
                item.Price < 0 ||
                item.Quantity < 0)
                return false;
        }


        // proccessdate, processing date
        if (!order.DateProcessing.HasValue || order.DateProcessed.HasValue)
            return false;

        // unique Id
        if (string.IsNullOrWhiteSpace(order.UniqueId))
            return false;

        // VAlidateCustomerInformation
        if (!ValidateCustomerInformation(order.CustomerName,
                                          order.CustomerAddress,
                                          order.CustomerCity,
                                          order.CustomerStateProvince,
                                          order.CustomerCountry))
            return false;

        return true;
    }
}
