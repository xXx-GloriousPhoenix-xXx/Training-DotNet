using Multithreading.General.Contexts;
using Multithreading.General.Classes;
namespace Multithreading.General.Services;

public static class PaymentService
{
    public static void ProcessPayment(Order order)
    {
        var message = "Processing payment";
        var orderId = order.Id;
        var processTime = 300;
        var info = new LimitedOrderOpeartionContext(message, orderId);
        info.WrapOperation(() =>
        {
            Thread.Sleep(processTime);
        });
    }
}
