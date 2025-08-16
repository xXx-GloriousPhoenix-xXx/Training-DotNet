using Multithreading.Tasks.Task_1;
using Multithreading.Tasks.Task_2;
using Multithreading.Tasks.Task_3;

namespace Multithreading;
public static class Program
{
    public static async Task Main()
    {
        //await Task_1.Test();
        //await Task_2.Test();
        Task_3.Test();
    }
}