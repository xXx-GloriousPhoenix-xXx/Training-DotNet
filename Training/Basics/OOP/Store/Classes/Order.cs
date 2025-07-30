using Basics.OOP.General.Interfaces;

namespace Basics.OOP.Store.Classes;

public class Order(Customer customer, List<Product>? products, DateOnly date) : IPrintable
{
    public Customer Customer { get; set; } = customer;
    public List<Product> Products { get; set; } = products ?? [];
    public DateOnly Date { get; set; } = date;
    public decimal GetTotalPrice() => Products.Sum(p => p.Price);
    public int GetUniqueCount() => Products.DistinctBy(p => p.Name).Count();
    public void PrintOrder()
    {
        Console.WriteLine($"Customer: {Customer.Name}");
        var product_groups = Products.GroupBy(p => p.Name);
        foreach (var group in product_groups)
        {
            var quantity = group.Count();
            var price_single = group.First().Price;
            Console.WriteLine(
                $"{group.Key}x{quantity}:\t{price_single * quantity}"
            );
        }
    }
    public void PrintInfo() => PrintOrder();
}
