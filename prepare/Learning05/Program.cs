using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 4);
        shapes.Add(s1);

        Rectangle r1 = new Rectangle("Green", 5, 6);
        shapes.Add(r1);

        Circle c1 = new Circle("Blue", 3);;
        shapes.Add(c1);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"Shape Color: {color}, Area: {area}");
        }
    
    }
}