using Basics.OOP.Classes;

namespace Basics.OOP.Interfaces;
public interface IStoreSearchable
{
    public IEnumerable<Order> GetOrdersByCustomer(string customerId);
    public IEnumerable<Product> GetProductsCheaperThan(decimal maxPrice);
}