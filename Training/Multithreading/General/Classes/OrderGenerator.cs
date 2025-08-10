namespace Multithreading.General.Classes;

public static class OrderGenerator
{
    public static IEnumerable<Order> Generate(int count)
    {
        var rnd = Random.Shared;
        for (var i = 0; i < count; i++)
        {
            var id = i;
            var customer = $"Customer_{i}";
            var cost = 100m * rnd.Next(5, 11);
            Console.WriteLine($"Generated order #{i} cost={cost}");
            yield return new Order(id, customer, cost);
        }
    }
}
