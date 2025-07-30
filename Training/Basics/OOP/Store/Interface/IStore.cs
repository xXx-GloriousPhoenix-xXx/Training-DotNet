using Basics.OOP.Store.Classes;

namespace Basics.OOP.Store.Interfaces;

public interface IStore
{
    public void AddProduct(Product product);
    public void PlaceOrder(Order order);
}