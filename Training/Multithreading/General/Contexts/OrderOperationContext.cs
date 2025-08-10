using Multithreading.General.Interfaces;

namespace Multithreading.General.Contexts;

public abstract class OrderOperationContext : IWrapperable
{
    public abstract string OperationMessage { get; set; }
    public abstract int OrderId { get; set; }
    public virtual string GetExtraInfo() => string.Empty;
    public void PrintOperationMessage(bool isFinished, long elapsedMs = 0)
    {
        var time = DateTime.Now;
        var message = $"[{time:HH:mm:ss.fff}]";
        message += $"[Thread {Environment.CurrentManagedThreadId}]";
        message += $" {OperationMessage}";
        message += $"for order #{OrderId}";

        var extraInfo = GetExtraInfo();
        if (!string.IsNullOrEmpty(extraInfo))
            message += $" {extraInfo}";

        message += isFinished ? $" END (took {elapsedMs} ms)" : " START";
        Console.WriteLine(message);
    }
    public void WrapOperation(Action internalFunction)
    {

        PrintOperationMessage(false);
        var sw = System.Diagnostics.Stopwatch.StartNew();

        internalFunction();

        sw.Stop();
        PrintOperationMessage(true, sw.ElapsedMilliseconds);
    }
}
