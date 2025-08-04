using Basics.Classes;

namespace Basics.Interfaces;
public interface IStoreSearchable
{
    public IEnumerable<Order> GetOrdersByCustomer(string customerId);
    public IEnumerable<Product> GetProductsCheaperThan(decimal maxPrice);
}