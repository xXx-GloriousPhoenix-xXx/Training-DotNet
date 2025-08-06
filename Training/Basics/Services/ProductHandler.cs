using System.Collections.Concurrent;
using Basics.Classes;

namespace Basics.Services;
public static class ProductHandler
{
    private static readonly int MIN_PRODUCTS_QUANTITY_RATIO = 1000;
    public static List<Product> GenerateRandomProductsAdaptive(int productsQuantity)
    {
        if (productsQuantity <= 0) return [];
        var threadQuantity = Environment.ProcessorCount;
        if (productsQuantity / threadQuantity <= MIN_PRODUCTS_QUANTITY_RATIO)
        {
            return GenerateRandomProducts(productsQuantity);
        }
        else
        {
            return GenerateRandomProductsParallel(productsQuantity);
        }
    }
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
            var product = GenerateTemplateProduct(i);
            bag.Add(product);
        });
        return [.. bag];
    }
    public static List<Product> GenerateRandomProducts(int productQuantity)
    {
        if (productQuantity <= 0) return [];
        var products = new List<Product>();
        for (var i = 0; i < productQuantity; i++)
        {
            var product = GenerateTemplateProduct(i);
            products.Add(product);
        }
        return products;
    }
    public static Product GenerateTemplateProduct(int identifier)
    {
        var prodName = $"Name_{identifier}";
        var prodPrice = identifier;
        var p = new Product(prodName, prodPrice);
        return p;
    }
}
