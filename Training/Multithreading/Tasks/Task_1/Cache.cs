using System.Collections.Concurrent;
namespace Multithreading.Tasks.Task_1;
public class Cache
{
    private readonly ConcurrentDictionary<string, CacheItem> _data = [];
    public bool Set(string key, object value, int timeToLive)
    {
        var expiresAt = DateTime.UtcNow.AddMilliseconds(timeToLive);
        var cts = new CancellationTokenSource();

        var newItem = new CacheItem(value, expiresAt, cts);

        if (_data.TryGetValue(key, out var oldItem))
        {
            oldItem.CancellationTokenSource?.Cancel();
        }

        _data.AddOrUpdate(key, newItem, (k, old) =>
        {
            old.CancellationTokenSource?.Cancel();
            return newItem;
        });

        _ = Task.Run(async () =>
        {
            try
            {
                await Task.Delay(timeToLive);
                Remove(key);
            }
            catch { }
        });

        return true;
    }
    public CacheItem? Get(string key)
    {
        _data.TryGetValue(key, out var value);
        return value;
    }
    public bool Remove(string key)
    {
        if (_data.TryRemove(key, out var item))
        {
            item.CancellationTokenSource?.Cancel();
            item.CancellationTokenSource?.Dispose();
            return true;
        }
        return false;
    }
}
