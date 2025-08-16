namespace Multithreading.Tasks.Task_1;
public class CacheItem(object _Value, DateTime _ExpireAt, CancellationTokenSource _CancellationTokenSource)
{
    public object Value { get; set; } = _Value;
    public DateTime ExpiresAt { get; set; } = _ExpireAt;
    public CancellationTokenSource CancellationTokenSource { get; set; } = _CancellationTokenSource;
}
