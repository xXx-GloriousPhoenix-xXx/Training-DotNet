using Multithreading.Contexts;
using Multithreading.General.Classes;
namespace Multithreading.General.Services;

public static class NotificationService
{
    public static void SendNotification(Order order)
    {
        var message = "Sending notification";
        var orderId = order.Id;
        var processTime = 200;
        var info = new LimitedOrderOpeartionContext(message, orderId);
        info.WrapOperation(() =>
        {
            Thread.Sleep(processTime);
        });
    }
}