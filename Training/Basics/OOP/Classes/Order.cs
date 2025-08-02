using Basics.OOP.Interfaces;

namespace Basics.OOP.Classes;

public class Order(Customer customer, Dictionary<Product, ushort>? products, DateOnly date) : IPrintable, IOrderExportable, IOrderOperatable
{
    public Customer Customer { get; set; } = customer;
    public Dictionary<Product, ushort> Products { get; set; } = products ?? [];
    public DateOnly Date { get; set; } = date;
    public decimal GetTotalPrice() => Products.Sum(pair => pair.Key.Price * pair.Value);
    public void AddProduct(Product product)
    {
        if (Products.TryGetValue(product, out ushort value))
        {
            Products[product] = ++value;
        }
        else
        {
            Products.Add(product, 0);
        }
    }
    public int GetUniqueCount() => Products.Keys.Count;
    public void PrintInfo()
    {
        Console.WriteLine($"Customer: {Customer.Name}");
        foreach (var product in Products)
        {
            var total_price = product.Key.Price * product.Value;
            Console.WriteLine(
                $"-\t{product.Key.Name} x {product.Value}:\t{total_price}"
            );
        }
        Console.WriteLine($"Total:\t{GetTotalPrice()}");
    }
    public void ExportToText(string path = "../../../OOP/Data/OrderWrite/Order.txt")
    {
        using var sw = new StreamWriter(path);
        sw.WriteLine($"Customer: {Customer.Name}");
        foreach (var product in Products)
        {
            var total_price = product.Key.Price * product.Value;
            sw.WriteLine(
                $"-\t{product.Key.Name} x {product.Value}:\t{total_price}"
            );
        }
        sw.WriteLine($"Total:\t{GetTotalPrice()}");
    }
}
