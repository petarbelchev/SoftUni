using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = 0;
            string geometricShape = Console.ReadLine();

            if (geometricShape == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (geometricShape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (geometricShape == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * (r * r);
            }
            else if (geometricShape == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                area = (a * ha) / 2;
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
