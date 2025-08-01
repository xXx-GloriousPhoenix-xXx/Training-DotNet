using Basics.OOP.Interfaces;

namespace Basics.OOP.Services;
public static class PrintHandler
{
    public static void PrintAll(this List<IPrintable> printables)
    {
        foreach (var printable in printables)
        {
            printable.PrintInfo();
        }
    }
}