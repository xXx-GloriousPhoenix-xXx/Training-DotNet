using Basics.Interfaces;
namespace Basics.OOP.Classes;
public class Student(string group, string name, ushort age) : Person(name, age)
{
    public string Group { get; set; } = group;
    public override void Introduce()
    {
        Console.Write($"I am a student of a group {Group}, ");
        base.Introduce();
    }
}
public class Teacher(string subject, string name, ushort age) : Person(name, age)
{
    public string Subject { get; set; } = subject;
    public override void Introduce()
    {
        Console.Write($"I am a {Subject} teacher, ");
        base.Introduce();
    }
}