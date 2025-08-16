namespace Multithreading.Tasks.Task_2;

public class HTTPController(int requestLimit)
{
    private readonly SemaphoreSlim _semaphore = new (requestLimit, requestLimit);
    public async Task ExecuteAsync(Func<Task> request)
    {
        await _semaphore.WaitAsync();
        try 
        {
            await request(); 
        }
        finally 
        { 
            _semaphore.Release(); 
        }
    }
}
