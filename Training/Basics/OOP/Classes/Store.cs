using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;
public class Store(List<Product>? products, Queue<Order>? orders) : IStore, IPrintable, IStoreSearchable
{
    public List<Product> Catalogue { get; set; } = products ?? [];
    public Queue<Order> Orders { get; set; } = orders ?? [];
    public void AddProduct(Product product)
    {
        Catalogue.Add(product);
    }
    public void PlaceOrder(Order order)
    {
        Orders.Enqueue(order);
    }
    public Order ProcessOrder()
    {
        return Orders.Dequeue();
    }
    public IEnumerable<Order> GetOrdersByCustomer(string customerName)
    {
        return Orders.Where(o => o.Customer.Name == customerName);
    }
    public IEnumerable<Product> GetProductsCheaperThan(decimal maxPrice)
    {
        return Catalogue.Where(c => c.Price <= maxPrice);
    }
    public void PrintInfo()
    {
        foreach (var product in Catalogue)
        {
            product.PrintInfo();
        }
        foreach (var order in Orders)
        {
            order.PrintInfo();
        }
    }
}