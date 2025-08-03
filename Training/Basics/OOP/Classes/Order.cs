using Basics.OOP.Interfaces;
using System.Globalization;

namespace Basics.OOP.Classes;

public class Order(Customer customer, Dictionary<Product, ushort>? products, DateOnly date) : IPrintable, IOrderExportable, IOrderOperatable
{
    public Order(Customer customer, List<Product> products, DateOnly date)
    : this(customer,
        products.GroupBy(p => p).ToDictionary(g => g.Key, g => (ushort)g.Count()),
        date
    ) { }
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
    public void PrintInfo(TextWriter writer)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        writer.WriteLine($"Customer: {Customer.Name}");
        foreach (var product in Products)
        {
            var total_price = product.Key.Price * product.Value;
            writer.WriteLine(
                $" - {product.Key.Name} x {product.Value}: {total_price}$"
            );
        }
        writer.WriteLine($"Total: {GetTotalPrice()}$");
    }
    public void PrintInfo() => PrintInfo(Console.Out);
    public void ExportToText(string path = "../../../OOP/Data/OrderWrite/Order.txt")
    {
        using var sw = new StreamWriter(path);
        PrintInfo(sw);
    }
}