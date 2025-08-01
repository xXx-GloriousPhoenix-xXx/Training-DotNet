namespace Basics.OOP.Interfaces;

public interface IOrderExportable
{
    public void ExportToText(string path);
}
public interface IOrderOperatable
{
    public void AddProduct();
}