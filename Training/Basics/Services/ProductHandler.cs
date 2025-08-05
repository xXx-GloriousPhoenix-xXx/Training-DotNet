using System.Collections.Concurrent;
using Basics.Classes;

namespace Basics.Services;
public static class ProductHandler
{
    private const int MIN_PRODUCTS_PER_THREAD = 10;
    public static Task<List<Product>> GenerateRandomProductsAdaptive(int productsQuantity)
    {
        if (productsQuantity <= 0)
        {
            return Task.FromResult(new List<Product>());
        }

        var threadsCount = Environment.ProcessorCount;

        if (productsQuantity / threadsCount <= MIN_PRODUCTS_PER_THREAD)
        {
            var result = GenerateRandomProductsSingleThread(productsQuantity);
            return Task.FromResult(result);
        }
        else
        {
            return GenerateRandomProductsParallelAsync(productsQuantity); 
        }
    }
    public static async Task<List<Product>> GenerateRandomProductsParallelAsync(int productsQuantity)
    {
        if (productsQuantity <= 0)
        {
            return [];
        }

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

        await Task.WhenAll([.. tasks]);
        return [.. bag];
    }
    public static List<Product> GenerateRandomProductsSingleThread(int productsQuantity)
    {
        if (productsQuantity <= 0)
        {
            return [];
        }

        var products = new List<Product>();

        for (var i = 0; i < productsQuantity; i++)
        {
            var prodName = $"Name_{i}";
            var prodPrice = i;
            var p = new Product(prodName, prodPrice);
            products.Add(p);
        }

        return products;
    }
}
