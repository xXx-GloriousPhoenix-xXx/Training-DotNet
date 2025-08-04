using Basics.Interfaces;

namespace Basics.Services;

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