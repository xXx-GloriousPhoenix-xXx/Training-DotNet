namespace Basics.OOP.Classes;
public class Customer(string name, string email, Address address) : User(name, email)
{
    public Address Address { get; set; } = address;
    public override void PrintInfo()
    {
        base.PrintInfo();
        Address.PrintInfo();
    }
}
