using Basics.Classes;

namespace Basics.Interfaces;

public interface IStore
{
    public void AddProduct(Product product);
    public void PlaceOrder(Order order);
    public Order ProcessOrder();
}