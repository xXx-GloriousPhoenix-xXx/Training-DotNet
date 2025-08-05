using System.Collections.Concurrent;
using Basics.Interfaces;
namespace Basics.Classes;
public class Store(List<Product>? products, ConcurrentQueue<Order>? orders) : IStore, IPrintable, IStoreSearchable
{
    public List<Product> Catalogue { get; set; } = products ?? [];
    public ConcurrentQueue<Order> Orders { get; set; } = orders ?? [];
    public void AddProduct(Product product)
    {
        Catalogue.Add(product);
    }
    public void PlaceOrder(Order order)
    {
        Orders.Enqueue(order);
    }
    public void PlaceOrders(List<Order> orders)
    {
        orders.ForEach(o => PlaceOrder(o));
    }
    public Order ProcessOrder()
    {
        if (Orders.TryDequeue(out var value))
        {
            return value;
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
    public IEnumerable<Order> GetOrdersByCustomer(string customerName)
    {
        return Orders.Where(o => o.Customer.Name == customerName);
    }
    public IEnumerable<Product> GetProductsCheaperThan(decimal maxPrice)
    {
        return Catalogue.Where(c => c.Price <= maxPrice);
    }
    public void PrintInfo()
    {
        foreach (var product in Catalogue)
        {
            product.PrintInfo();
        }
        foreach (var order in Orders)
        {
            order.PrintInfo();
        }
    }
    public void PrintAllOrders()
    {
        Orders.ToList().ForEach(o => o.PrintInfo());
    }
    public async Task ProcessAllOrdersParallelAsync(string dirPath)
    {
        var tasks = new List<Task>();

        var orderCount = Orders.Count;
        if (orderCount == 0)
        {
            return;
        }

        var threadCount = Environment.ProcessorCount;
        var ordersPerThread = orderCount / threadCount;
        var ordersRemainder = orderCount % threadCount;

        for (var i = 0; i < threadCount; i++)
        {
            var threadIndex = i;
            var count = ordersPerThread + (threadIndex < ordersRemainder ? 1 : 0);
            tasks.Add(Task.Run(async () =>
            {
                for (var j = 0; j < count; j++)
                {
                    if (!Orders.TryDequeue(out var order))
                    {
                        throw new ArgumentNullException(paramName: nameof(order));
                    }

                    var path = Path.Combine(dirPath, $"Order_{threadIndex}_{j}.txt");
                    await order.PrintInfoAsync();
                    await order.ExportToTextAsync(path);
                }
            }));
        }

        await Task.WhenAll(tasks);
    }
}