using Basics.OOP.Classes;

namespace Basics.OOP.Services;

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