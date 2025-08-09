using Multithreading.Utilities;
using Multithreading.Classes;
using System.Diagnostics;
namespace Multithreading;
public static class Test
{
    public static void Main()
    {
        MergeUtility.MergeAllFiles();

        var orders = OrderGenerator.Generate(100);
        var time = WrapTime(() =>
        {
            Parallel.ForEach(orders, order =>
            {
                order.Process();
            });
        });
        Console.WriteLine($"Total time taken: {time.ElapsedMilliseconds} ms");

    }
    public static Stopwatch WrapTime(Action operation)
    {
        var sw = Stopwatch.StartNew();
        operation();
        sw.Stop();
        return sw;
    }
}