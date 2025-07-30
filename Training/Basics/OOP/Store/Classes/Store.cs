using Basics.OOP.General.Interfaces;
using Basics.OOP.Store.Interfaces;

namespace Basics.OOP.Store.Classes;
public class Store(List<Product>? products, List<Order>? orders) : IStore, IPrintable
{
    public List<Product> Catalogue { get; set; } = products ?? [];
    public List<Order> Orders { get; set; } = orders ?? [];
    public void AddProduct(Product product)
    {
        Catalogue.Add(product);
    }
    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
    }
    public void PrintAllOrders()
    {
        foreach (var order in Orders)
        {
            order.PrintOrder();
        }
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