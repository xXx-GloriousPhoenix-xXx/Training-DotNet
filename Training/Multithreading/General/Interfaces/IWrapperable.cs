namespace Multithreading.General.Interfaces;
public interface IWrapperable
{
    public void PrintOperationMessage(bool isFinished, long elapsedMs = 0);
    public void WrapOperation(Action internalFunction);
}
