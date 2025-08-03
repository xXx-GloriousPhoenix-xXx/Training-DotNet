using Basics.OOP.Classes;
using Basics.OOP.Services;
using Basics.Utilities;

namespace Basics;
public static class Test
{
    public static void TestSaveOrder()
    {
        var products = new List<Product>()
        {
            new("IPhone", 500.00m),
            new("Samsung", 300.00m),
            new("Samsung", 300.00m),
            new("Xiaomi", 150.00m),
            new("Xiaomi", 150.00m),
            new("Xiaomi", 150.00m)
        };
        var address = new Address("Ukraine", "Kyiv", "Khreschatic", 19);
        var customer = new Customer("Roman", "romaprihodko2006@gmail.com", address);
        var date = new DateOnly(2025, 7, 31);
        var order = new Order(customer, products, date);
        order.ExportToText();
    }
    public static void TestLibrarySaveLoad()
    {
        const int max = 5;
        var books = new List<Book>();
        for (var i = 1; i <= 5; i++)
        {
            var book1 = new Book($"title_{i}", $"author_{i}", (ushort)(2020 + i));
            var book2 = new Book($"title_{i + max}", $"author_{i}", (ushort)(2020 + (max + 1) - i));
            books.Add(book1);
            books.Add(book2);
        }

        var library = new Library(books);
        library.SaveToFile();
        var newLibrary = LibraryHandler.LoadFromFile("../../../OOP/Data/LibraryWrite/Library.json");
        if (newLibrary is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            newLibrary.PrintInfo();
        }
    }
    public static void Main()
    {
        Directory.GetDirectories("../../../OOP").ToList().Merge();

        var testcase = TestLibrarySaveLoad;
        testcase();
    }
} 
