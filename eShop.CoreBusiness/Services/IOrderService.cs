
using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(string name, string address, string city, string stateprovince, string country);
        bool ValidateCreateOrder(Order order);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}
