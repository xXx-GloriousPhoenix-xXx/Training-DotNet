namespace Multithreading.Interfaces;

public interface ILimitedOrderOperationContext
{
    public string OperationMessage { get; set; }
    public int OrderId { get; set; }
}
