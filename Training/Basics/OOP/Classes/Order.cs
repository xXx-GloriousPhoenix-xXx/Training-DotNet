using Basics.OOP.Interfaces;

namespace Basics.OOP.Classes;

public class Order(Customer customer, Dictionary<Product, ushort>? products, DateOnly date) : IPrintable, IOrderExportable, IOrderOperatable
{
    public Customer Customer { get; set; } = customer;
    //public IEnumerable<Product> Products { get; set; } = products ?? [];
    public Dictionary<Product, ushort> Products { get; set; } = 
    public DateOnly Date { get; set; } = date;
    public decimal GetTotalPrice() => Products.Sum(p => p.Price);
    public void AddProduct()
    {
        throw new NotImplementedException();
    }
    public int GetUniqueCount() => Products.DistinctBy(p => p.Name).Count();
    public void PrintInfo()
    {
        Console.WriteLine($"Customer: {Customer.Name}");
        var product_groups = Products.GroupBy(p => p.Name);
        foreach (var group in product_groups)
        {
            var quantity = group.Count();
            var price_single = group.First().Price;
            Console.WriteLine(
                $"-\t{group.Key}x{quantity}:\t{price_single * quantity}"
            );
        }
        Console.WriteLine($"Total:\t{GetTotalPrice()}");
    }
    public void ExportToText(string path = "../../../OOP/Data/OrderWrite/Order.txt")
    {
        using var sw = new StreamWriter(path);
        sw.WriteLine($"Customer: {Customer.Name}");
        var product_groups = Products.GroupBy(p => p.Name);
        foreach (var group in product_groups)
        {
            var quantity = group.Count();
            var price_single = group.First().Price;
            sw.WriteLine(
                $"-\t{group.Key}x{quantity}:\t{price_single * quantity}"
            );
        }
        sw.WriteLine($"Total:\t{GetTotalPrice()}");
    }
}
