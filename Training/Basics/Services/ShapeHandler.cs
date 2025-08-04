using Basics.Classes;

namespace Basics.Services;

public static class ShapeHandler
{
    public static void PrintAllAreas(List<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetArea());
        }
    }
}