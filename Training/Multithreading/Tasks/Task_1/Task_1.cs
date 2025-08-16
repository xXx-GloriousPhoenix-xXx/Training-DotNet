namespace Multithreading.Tasks.Task_1;
public static class Task_1
{
    public static async Task Test()
    {
        var cache = new Cache();
        var key = "test_key";
        var value = "test_value";
        var time_to_live = 2000; //2s

        cache.Set(key, value, time_to_live);
        Console.WriteLine($"Value: {cache.Get(key)?.Value}, Delay: Immediate");

        await Task.Delay(time_to_live / 2);
        Console.WriteLine($"Value: {cache.Get(key)?.Value}, Delay: 1s");

        await Task.Delay(time_to_live / 4);
        Console.WriteLine($"Value: {cache.Get(key)?.Value}, Delay: 1.5s");

        await Task.Delay(time_to_live / 8);
        Console.WriteLine($"Value: {cache.Get(key)?.Value}, Delay: 1.75s");

        await Task.Delay(time_to_live / 8);
        Console.WriteLine($"Value: {cache.Get(key)?.Value ?? "Deleted"}, Delay: 2s");
    }
}
