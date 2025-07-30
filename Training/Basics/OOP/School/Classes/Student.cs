namespace Basics.OOP.School.Classes;
public class Student(string group, string name, ushort age) : Person(name, age)
{
    public string Group { get; set; } = group;
    public override void Introduce()
    {
        Console.Write($"I am a student of a group {Group}, ");
        base.Introduce();
    }
}
