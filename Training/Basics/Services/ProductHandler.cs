using System.Collections.Concurrent;
using Basics.Classes;

namespace Basics.Services;
public static class ProductHandler
{
    public static List<Product> GenerateRandomProducts(int productsQuantity)
    {
        var bag = new ConcurrentBag<Product>();
        var tasks = new List<Task>();

        var threadCount = Environment.ProcessorCount;
        var prodPerThread = productsQuantity / threadCount;
        var prodRemainder = productsQuantity % threadCount;

        for (var i = 0; i < threadCount; i++)
        {
            var threadIndex = i;
            tasks.Add(Task.Run(() =>
            {
                var rnd = Random.Shared;
                var prodsToCreate = prodPerThread + (threadIndex < prodRemainder ? 1 : 0);
                for (var j = 0; j < prodsToCreate; j++)
                {
                    var prodName = $"Name_{threadIndex}_{j}";
                    var prodPrice = 10 * threadIndex + j;
                    var p = new Product(prodName, prodPrice);
                    bag.Add(p);
                }
            }));
        }

        Task.WaitAll([.. tasks]);
        return [.. bag];
    }
}
