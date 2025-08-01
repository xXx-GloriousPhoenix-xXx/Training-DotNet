using Basics.OOP.Interfaces;

namespace Basics.OOP.Classes;

public class User(string name, string email) : IUserInfo, IPrintable
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Email: {Email}");
    }
}