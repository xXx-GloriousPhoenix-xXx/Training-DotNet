using Basics.Interfaces;

namespace Basics.Classes;
public abstract class Shape(string name) : IAreaComputable, IPrintable
{
    public string Name { get; set; } = name;
    public abstract double GetArea();
    public void PrintInfo()
    {
        Console.WriteLine($"{Name}: {GetArea()}");
    }
}
