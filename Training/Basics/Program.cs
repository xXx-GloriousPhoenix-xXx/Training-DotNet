using Basics.OOP.Classes;
using Basics.Utilities;

namespace Basics;
public static class Test
{
    public static void Main()
    {
        Directory.GetDirectories("../../../OOP").ToList().Merge();

        var products = new List<Product>()
        {
            new("IPhone", 500.00m),
            new("Samsung", 300.00m),
            new("Samsung", 300.00m),
            new("Xiomi", 150.00m),
            new("Xiomi", 150.00m),
            new("Xiomi", 150.00m)
        };
        var address = new Address("Ukraine", "Kyiv", "Khreschatic", 19);
        var customer = new Customer("Roman", "romaprihodko2006@gmail.com", address);
        var date = new DateOnly(2025, 7, 31);
        var order = new Order(customer, products, date);
        order.ExportToText();
    }
} 
