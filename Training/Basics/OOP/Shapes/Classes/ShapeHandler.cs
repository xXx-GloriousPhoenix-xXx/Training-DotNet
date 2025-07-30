namespace Basics.OOP.Shapes.Classes;

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