using Basics.OOP.General.Interfaces;

namespace Basics.OOP.General.Classes;
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