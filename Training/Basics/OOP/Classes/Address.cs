using Basics.OOP.Interfaces;

namespace Basics.OOP.Classes;

public class Address(string country, string city, string street, ushort buildingNumber) : IPrintable
{
    public string Country { get; set; } = country;
    public string City { get; set; } = city;
    public string Street { get; set; } = street;
    public ushort BuildingNumber { get; set; } = buildingNumber;
    public void PrintInfo()
    {
        Console.WriteLine($"{Country} {City} {Street} {BuildingNumber}");
    }
}