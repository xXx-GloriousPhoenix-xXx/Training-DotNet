using Basics.Classes;
using System.Collections.Concurrent;
namespace Basics.Services;
public static class OrderHandler
{
    private static readonly int MIN_ORDERS_QUANTITY_RATIO = 1000;
    public static List<Order> GenerateRandomOrdersAdaptive(int ordersQuantity, int productsPerOrder)
    {
        if (ordersQuantity <= 0) return [];
        if (productsPerOrder <= 0)
        {
            throw new ArgumentException("Quantity of products per order must be positive integer", nameof(productsPerOrder));
        }
        var threadQuantity = Environment.ProcessorCount;
        if (ordersQuantity / threadQuantity <= MIN_ORDERS_QUANTITY_RATIO)
        {
            return GenerateRandomOrders(ordersQuantity, productsPerOrder);
        }
        else
        {
            return GenerateRandomOrdersParallel(ordersQuantity, productsPerOrder);
        }
        
    }
    public static List<Order> GenerateRandomOrdersParallel(int ordersQuantity, int productsPerOrder)
    {
        if (ordersQuantity <= 0) return [];
        if (productsPerOrder <= 0)
        {
            throw new ArgumentException("Quantity of products per order must be positive integer", nameof(productsPerOrder));
        }

        var bag = new ConcurrentBag<Order>();

        Parallel.For(0, ordersQuantity, new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        },
        i =>
        {
            var order = GenerateTemplateOrder(i, productsPerOrder);
            bag.Add(order);
        });

        return [.. bag];
    }
    public static List<Order> GenerateRandomOrders(int ordersQuantity, int productsPerOrder)
    {
        if (ordersQuantity <= 0) return [];
        if (productsPerOrder <= 0)
        { 
            throw new ArgumentException("Quantity of products per order must be positive integer", nameof(productsPerOrder));
        }

        var bag = new List<Order>();
        
        for (var i = 0; i < ordersQuantity; i++)
        {
            var order = GenerateTemplateOrder(i, productsPerOrder);
            bag.Add(order);
        }

        return [.. bag];
    }
    public static Order GenerateTemplateOrder(int identifier, int productsPerOrder)
    {
        if (productsPerOrder <= 0)
        {
            throw new ArgumentException("Quantity of products must be positive integer", nameof(productsPerOrder));
        }

        var customer = CustomerHandler.GenerateTemplateCustomer(identifier);
        var products = ProductHandler.GenerateRandomProducts(productsPerOrder);
        var date = new DateOnly(identifier + 1, 1, 1);
        var order = new Order(customer, products, date);
        return order;
    }
}
