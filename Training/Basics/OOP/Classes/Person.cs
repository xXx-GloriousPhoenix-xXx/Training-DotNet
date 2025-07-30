using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;
public class Person(string name, ushort age) : IPresentable
{
    public string Name { get; set; } = name;
    public ushort Age { get; set; } = age;
    public virtual void Introduce()
    {
        Console.WriteLine($"My name is {Name}, I am {Age} years old");
    }
}
public static class PersonHandler
{
    public static void IntroduceAll(this List<IPresentable> presentables)
    {
        foreach (var presentable in presentables)
        {
            presentable.Introduce();
        }
    }
}