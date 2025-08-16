using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Multithreading.Tasks.Task_2;

public static class Task_2
{
    public static async Task Test()
    {
        var taskQuantity = 10;
        var taskLimit = 3;
        var tasks = Enumerable.Range(1, taskQuantity)
            .Select(index => new Func<Task>(async () =>
        {
            var request = new HTTPRequst($"https://some/address/to/test/{index}");
            Console.WriteLine($"Peding request: {request.Address} START");
            await Task.Delay(1000);
            Console.WriteLine($"Peding request: {request.Address} END");
        }));
        var controller = new HTTPController(taskLimit);
        var executionTasks = tasks.Select(controller.ExecuteAsync);
        await Task.WhenAll(executionTasks);
    }
}
