using Basics.Interfaces;

namespace Basics.Services;
public static class PrintHandler
{
    public delegate void PrintDelegate(IPrintable printable);
    public static void PrintAll(this List<IPrintable> printables, PrintDelegate printer)
    {
        foreach (var printable in printables)
        {
            printer(printable);
        }
    }
}