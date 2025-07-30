using Basics.OOP.General.Interfaces;
using Basics.OOP.Store.Interfaces;

namespace Basics.OOP.Store.Classes;

public class Customer(string name, string email) : ICustomerInfo, IPrintable
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Email: {Email}");
    }
}
