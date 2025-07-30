using Basics.OOP.General.Interfaces;
using Basics.OOP.School.Interfaces;
namespace Basics.OOP.School.Classes;
public class Person(string name, ushort age) : IPresentable, IPrintable
{
    public string Name { get; set; } = name;
    public ushort Age { get; set; } = age;
    public virtual void Introduce()
    {
        Console.WriteLine($"My name is {Name}, I am {Age} years old");
    }
    public void PrintInfo() => Introduce();
}
