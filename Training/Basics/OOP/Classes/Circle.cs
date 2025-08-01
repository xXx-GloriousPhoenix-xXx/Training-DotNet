namespace Basics.OOP.Classes;
public class Circle(double radius) : Shape("Circle")
{
    public double Radius { get; set; } = radius;
    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
