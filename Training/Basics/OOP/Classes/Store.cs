namespace Basics.OOP.Classes;
public class Product(string name, decimal price)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
}
public class Customer(string name, string email)
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
}
public class Order(Customer customer, List<Product>? products, DateOnly date)
{
    public Customer Customer { get; set; } = customer;
    public List<Product> Products { get; set; } = products ?? [];
    public DateOnly Date { get; set; } = date;
    public decimal GetTotalPrice() => Products.Sum(p => p.Price);
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
}
public class OnlineStore(List<Product>? products, List<Order>? orders)
{
    public List<Product> Catalogue { get; set; } = products ?? [];
    public List<Order> Orders { get; set; } = orders ?? [];
    public void AddProduct(Product product)
    {
        Catalogue.Add(product);
    }
    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
    }
    public void PrintAllOrders()
    {
        foreach (var order in Orders)
        {
            order.PrintOrder();
        }
    }
}