using System.Diagnostics;
using Multithreading.General.Utilities;
using Multithreading.General.Classes;
using Multithreading.General.Services;
using System.Threading.Tasks;
namespace Multithreading;
public static class Test
{
    public static void Main()
    {
        MergeUtility.MergeAllFiles();

        Measure(async () =>
        {
            await ExecutePipeline();
        });
    }
    public static async Task ExecutePipeline()
    {
        var orders = OrderGenerator.Generate(100);

        var pair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, maxConcurrencyLevel: 1);
        var exclusiveScheduler = pair.ExclusiveScheduler;

        var limitedScheduler = new LimitedConcurrencyLevelTaskScheduler(3);
        
        var tasks = orders.Select(order =>
            System.Threading.Tasks.Task.Factory.StartNew(() => order.Process(),
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.Default
            )
            .ContinueWith(_ => PaymentService.ProcessPayment(order),
                CancellationToken.None,
                TaskContinuationOptions.None,
                exclusiveScheduler
            )
            .ContinueWith(_ => NotificationService.SendNotification(order),
                CancellationToken.None,
                TaskContinuationOptions.None,
                limitedScheduler
            )
        );

        await System.Threading.Tasks.Task.WhenAll(tasks);
    }
    public static void Measure(Action operation)
    {
        var sw = Stopwatch.StartNew();
        operation();
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds} ms");
    }
}
