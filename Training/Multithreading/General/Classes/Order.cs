using Multithreading.Contexts;
using Multithreading.General.Interfaces;

namespace Multithreading.General.Classes;
public class Order(int id, string customer, decimal cost) : IOrderable
{
    public int Id { get; set; } = id;
    public string Customer { get; set; } = customer;
    public decimal Cost { get; set; } = cost;
    public void Process()
    {
        var message = "Processing";
        var info = new DetailedOrderOperationContext(message, Id, Customer);
        info.WrapOperation(() =>
        {
            Thread.Sleep((int)Cost);
        });
    }
}
