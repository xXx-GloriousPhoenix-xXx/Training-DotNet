using Multithreading.Utilities;
using Multithreading.Classes;
using System.Diagnostics;

namespace Multithreading;
public static class Test
{
    public static void Main()
    {
        MergeUtility.MergeAllFiles();

        var orders = OrderGenerator.Generate(10);

        var pair = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, maxConcurrencyLevel: 1);
        var exclusiveScheduler = pair.ExclusiveScheduler;

        var limitedScheduler = new LimitedConcurrencyLevelTaskScheduler(3);
    }
    public static void Measure(Action operation)
    {
        var sw = Stopwatch.StartNew();
        operation();
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds} ms");
    }
}
public sealed class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
{
    private readonly int _maxDegreeOfParallelism;
    private readonly LinkedList<Task> _tasks = [];
    private int _runningTasks = 0;
    public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maxDegreeOfParallelism, 1);
        _maxDegreeOfParallelism = maxDegreeOfParallelism;
    }
    protected override IEnumerable<Task>? GetScheduledTasks()
    {
        return _tasks;
    }
    protected override void QueueTask(Task task)
    {
        _tasks.AddLast(task);
    }
    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
    {
        
    }
}