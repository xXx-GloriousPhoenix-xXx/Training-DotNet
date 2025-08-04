using Basics.OOP.Classes;
namespace Basics.OOP.Services;
public static class StoreHandler
{
    public static async Task ExportAllOrdersAsync(Store store, string folderPath)
    {
        var quantity = store.Orders.Count; 
        var taskList = store.Orders.Select((o, i) =>
        {
            var path = Path.Combine(folderPath, $"Order_{i + 1}");
            return o.ExportToTextAsync(path);
        });
        await Task.WhenAll(taskList);
    }
}
