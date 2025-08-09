using Multithreading.Interfaces;

namespace Multithreading.Contexts;

public class LimitedOrderOpeartionContext(string operationMessage, int orderId)
    : OrderOperationContext, ILimitedOrderOperationContext
{
    public override string OperationMessage { get; set; } = operationMessage;
    public override int OrderId { get; set; } = orderId;

}
