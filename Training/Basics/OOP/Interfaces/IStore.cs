using Basics.OOP.Classes;

namespace Basics.OOP.Interfaces;

public interface IStore
{
    public void AddProduct(Product product);
    public void PlaceOrder(Order order);
    public Order ProcessOrder();
}