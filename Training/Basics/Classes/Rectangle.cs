namespace Basics.Classes;
public class Rectangle(double width, double height) : Shape("Rectangle")
{
    public double Width { get; set; } = width;
    public double Height { get; set; } = height;
    public override double GetArea()
    {
        return Width * Height;
    }
}
