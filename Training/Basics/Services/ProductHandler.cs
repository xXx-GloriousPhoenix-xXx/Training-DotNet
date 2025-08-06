using System.Collections.Concurrent;
using Basics.Classes;

namespace Basics.Services;
public static class ProductHandler
{
    public static List<Product> GenerateRandomProductsParallel(int productQuantity)
    {
        if (productQuantity <= 0) return [];

        var bag = new ConcurrentBag<Product>();

        Parallel.For(0, productQuantity, new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        },
        i =>
        {
            var prodName = $"Name_{i}";
            var prodPrice = i;
            var p = new Product(prodName, prodPrice);
        })
    }
}
