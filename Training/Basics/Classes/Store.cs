using System.Collections.Concurrent;
using Basics.Interfaces;
namespace Basics.Classes;
public class Store(HashSet<Product>? products, ConcurrentQueue<Order>? orders) : IStore, IPrintable, IStoreSearchable
{
    public HashSet<Product> Catalogue { get; set; } = products ?? [];
    public ConcurrentQueue<Order> Orders { get; set; } = orders ?? [];
    public Store(ConcurrentQueue<Order> orders) : this(
        orders.SelectMany(o => o.Products.Keys).ToHashSet(),
        orders
    ) { }
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

        for (var i = 0; i < threadCount; i++)
        {
            var threadIndex = i;
            tasks.Add(Task.Run(async () =>
            {
                var orderIndex = 0;
                while (Orders.TryDequeue(out var order))
                {
                    var path = Path.Combine(dirPath, $"Order_{threadIndex}_{orderIndex}.txt");
                    //await order.PrintInfoAsync().ConfigureAwait(false);
                    await order.ExportToTextAsync(path).ConfigureAwait(false);
                    orderIndex++;
                }
            }));
        }

        await Task.WhenAll(tasks);
    }
    //public void ProcessAllOrdersParallel(string dirPath)
    //{
    //    var orderCount = Orders.Count;
    //    if (orderCount == 0) return;

    //    Parallel.For(0, orderCount, new ParallelOptions
    //    {
    //        MaxDegreeOfParallelism = Environment.ProcessorCount
    //    },
    //    i =>
    //    {

    //    });
    //}
}