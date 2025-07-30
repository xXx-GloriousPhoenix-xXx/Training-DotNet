using Basics.OOP.General.Interfaces;
using Basics.OOP.Shapes.Interfaces;
namespace Basics.OOP.Shapes.Classes;
public abstract class Shape(string name) : IAreaComputable, IPrintable
{
    public string Name { get; set; } = name;
    public abstract double GetArea();
    public void PrintDescription()
    {
        Console.WriteLine($"{Name}: {GetArea()}");
    }
    public void PrintInfo() => PrintDescription();
}
