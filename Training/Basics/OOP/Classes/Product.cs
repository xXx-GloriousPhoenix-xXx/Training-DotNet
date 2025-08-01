using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;
public readonly record struct Product(string name, decimal price) : IPurchasable, IOrderable, IPrintable
{
    public string Name { get; } = name;
    public decimal Price { get; } = price;
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price}");
    }
}