using Basics.OOP.School.Interfaces;
namespace Basics.OOP.School.Classes;

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