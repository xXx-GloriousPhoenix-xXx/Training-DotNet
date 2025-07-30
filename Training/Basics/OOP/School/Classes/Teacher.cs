using Basics.OOP.Interfaces;
namespace Basics.OOP.School.Classes;
public class Teacher(string subject, string name, ushort age) : Person(name, age)
{
    public string Subject { get; set; } = subject;
    public override void Introduce()
    {
        Console.Write($"I am a {Subject} teacher, ");
        base.Introduce();
    }
}