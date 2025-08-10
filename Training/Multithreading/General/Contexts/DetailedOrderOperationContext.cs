using Multithreading.General.Interfaces;

namespace Multithreading.General.Contexts;
public class DetailedOrderOperationContext(string operationMessage, int orderId, string customer)
    : OrderOperationContext, IDetailedOrderOperationContext
{
    public override string OperationMessage { get; set; } = operationMessage;
    public override int OrderId { get; set; } = orderId;
    public string Customer { get; set; } = customer;
    public override string GetExtraInfo() => $"for customer «{Customer}»";
}