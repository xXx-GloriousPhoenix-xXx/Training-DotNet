namespace Multithreading.General.Interfaces;

public interface IOrderable
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public decimal Cost { get; set; }
    public void Process();
}
