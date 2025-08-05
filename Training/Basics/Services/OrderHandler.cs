using Basics.Classes;
using System.Collections.Concurrent;
namespace Basics.Services;
public static class OrderHandler
{
    public static async Task<List<Order>> GenerateRandomOrdersParallelAsync(int ordersQuantity, int productsPerOrder)
    {
        if (ordersQuantity <= 0)
        {
            return [];
        }

        var bag = new ConcurrentBag<Order>();
        var tasks = new List<Task>();

        var threadsCount = Environment.ProcessorCount;
        var ordersPerThread = ordersQuantity / threadsCount;
        var ordersRemainder = ordersQuantity % threadsCount;

        for (var i = 0; i < threadsCount; i++)
        {
            var threadIndex = i;
            tasks.Add(Task.Run(() =>
            {
                var count = ordersPerThread + (threadIndex < ordersRemainder ? 1 : 0);
                for (var j = 0; j < count; j++)
                {
                    var orderIndex = j;
                    var customer = CustomerHandler.GeneratePatternCustomer(threadIndex, orderIndex);
                    var products = ProductHandler.GenerateRandomProductsSingleThread(productsPerOrder);
                    var date = new DateOnly(threadIndex + orderIndex + 1, 1, 1);
                    var order = new Order(customer, products, date);
                    bag.Add(order);
                }
            }));
        }

        await Task.WhenAll(tasks);
        return [.. bag];
    }
}
