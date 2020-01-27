using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        public String Color{ get; set; }
        public bool IsFilled { get; set; }

        public Shape()
        {
            Color = "green";
            IsFilled = true;
        }

        public Shape(String color, bool filled)
        {
            Color = color;
            IsFilled = filled;
        }

        public abstract double Area();


        public abstract double Perimeter();

        public override String ToString()
        {
            return ("A Shape with color " + Color + " and" + (IsFilled ? null : " not") + " filled");
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius = 1.0) : base()
        {
            Radius = radius;
        }

        public Circle(double radius, String color, bool filled) : base(color, filled)
        {
            Radius = radius;
           
        }

        override public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        override public double Perimeter()
        {
            return Math.PI * 2 * Radius;
        }

        public override string ToString()
        {
            String from_base = base.ToString();
            Console.WriteLine(from_base);
            return ("A circle with radius=" + Radius + ",which is a derived class of " + from_base);
        }

        private double Radius { get; set; }
    }

    public class Rectangle : Shape
    {
        

        public Rectangle(double length = 1.0, double width = 1.0) : base()
        {
            Length = length;
            Width = width;
        }

        public Rectangle(double length, double width, String color, bool filled) : base(color, filled)
        {
            Length = length;
            Width = width;
           
        }

        static Rectangle()
        {
            Console.WriteLine("Rectangle class initialized!");
        }

        override public double Area()
        {
            return Length * Width;
        }

        override public double Perimeter()
        {
            return 2 * (Length + Width);
        }

        public override string ToString()
        {
            return ("A Rectangle with Width=" + Width + " and Length=" + Length + ",which is a derived class of " + base.ToString());
        }

        private double Length { get; set; }
        private double Width { get; set; }
    }

    public class ComplexShape : Shape
    {
        public ComplexShape()
        {
           
        }
        public void Add(Shape s)
        {
            basic_shapes.Add(s);
        }
        public override double Area()
        {
            double area = 0;
            foreach (Shape s in basic_shapes)
            {
                area += s.Area();
            }

            return area;
        }

        public override double Perimeter()
        {
            double perimeter = 0;
            foreach (Shape s in basic_shapes)
            {
                perimeter += s.Perimeter();
            }

            return perimeter;

        }
        private List<Shape> basic_shapes = new List<Shape>();


    }
}
