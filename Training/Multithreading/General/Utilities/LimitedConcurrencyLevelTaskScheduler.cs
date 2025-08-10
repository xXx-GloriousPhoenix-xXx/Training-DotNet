namespace Multithreading.General.Utilities;

public sealed class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
{
    private readonly int _maxDegreeOfParallelism;
    private readonly LinkedList<Task> _tasks = [];
    private int _runningTasks = 0;
    private readonly object _lock = new();
    public override int MaximumConcurrencyLevel => _maxDegreeOfParallelism;
    public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maxDegreeOfParallelism, 1);
        _maxDegreeOfParallelism = maxDegreeOfParallelism;
    }
    protected override IEnumerable<Task>? GetScheduledTasks()
    {
        lock (_lock)
        {
            return [.. _tasks];
        }
    }
    protected override void QueueTask(Task task)
    {
        lock (_lock)
        {
            _tasks.AddLast(task);
            if (_runningTasks < _maxDegreeOfParallelism)
            {
                StartNewTask();
            }
        }
    }
    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
    {
        if (_runningTasks >= _maxDegreeOfParallelism)
        {
            return false;
        }
        if (taskWasPreviouslyQueued)
        {
            lock (_lock)
            {
                _tasks.Remove(task);
            }
        }
        return TryExecuteTask(task);
    }
    private void StartNewTask()
    {
        Task? nextTask = null;
        lock (_lock)
        {
            if (_tasks.Count > 0)
            {
                nextTask = _tasks.First!.Value;
                _tasks.RemoveFirst();
                _runningTasks++;
            }
        }
        if (nextTask is not null)
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                try
                {
                    TryExecuteTask(nextTask);
                }
                finally
                {
                    TaskCompleted();
                }
            }, null);
        }
    }
    private void TaskCompleted()
    {
        lock (_lock)
        {
            _runningTasks--;
            if (_tasks.Count > 0)
            {
                StartNewTask();
            }
        }
    }
}