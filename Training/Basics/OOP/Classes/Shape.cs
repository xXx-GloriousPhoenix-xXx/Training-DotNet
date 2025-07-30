namespace Basics.OOP.Classes;
public abstract class Shape(string name)
{
    public string Name { get; set; } = name;
    public abstract double GetArea();
}
public class Circle(double radius) : Shape("Circle")
{
    public double Radius { get; set; } = radius;
    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
public class Rectangle(double width, double height) : Shape("Rectangle")
{
    public double Width { get; set; } = width;
    public double Height { get; set; } = height;
    public override double GetArea()
    {
        return Width * Height;
    }
}
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