namespace Multithreading.Interfaces;

public interface IDetailedOrderOperationContext : ILimitedOrderOperationContext
{
    public string Customer { get; set; }
}
