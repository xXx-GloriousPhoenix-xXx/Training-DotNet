using System.Collections.Concurrent;
using Basics.OOP.Classes;

namespace Basics.OOP.Services;
public static class ProductHandler
{
    public static List<Product> GenerateRandomProducts(int count)
    {
        var bag = new ConcurrentBag<Product>();
        var tasks = new List<Task>();

        int threadCount = Environment.ProcessorCount;

        for (var i = 0; i < threadCount; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                var rnd = new Random();
                var items = rnd.Next(10, 51);
                for (var j = 0; j < items; j++)
                {
                    var p = new Product($"Name_{j}", 100+j);
                    bag.Add(p);
                }
            }));
        }

        Task.WaitAll([..tasks]);
        return bag.Take(count).ToList();

    }
}
