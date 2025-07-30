using Basics.OOP.General.Interfaces;
using Basics.OOP.Store.Interfaces;
namespace Basics.OOP.Store.Classes;
public class Product(string name, decimal price) : IPurchasable, IOrderable, IPrintable
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
}
