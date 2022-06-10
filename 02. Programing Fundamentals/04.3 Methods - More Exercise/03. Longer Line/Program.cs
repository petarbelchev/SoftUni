using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstLineX1 = double.Parse(Console.ReadLine());
            double firstLineY1 = double.Parse(Console.ReadLine());
            double firstLineX2 = double.Parse(Console.ReadLine());
            double firstLineY2 = double.Parse(Console.ReadLine());

            double secondLineX1 = double.Parse(Console.ReadLine());
            double secondLineY1 = double.Parse(Console.ReadLine());
            double secondLineX2 = double.Parse(Console.ReadLine());
            double secondLineY2 = double.Parse(Console.ReadLine());

            double firstLineLength = GetLength(firstLineX1, firstLineY1, firstLineX2, firstLineY2);
            double secondLineLength = GetLength(secondLineX1, secondLineY1, secondLineX2, secondLineY2);

            Console.Write("(");

            if (firstLineLength >= secondLineLength)
            {
                double distance1 = GetDistance(firstLineX1, firstLineY1);
                double distance2 = GetDistance(firstLineX2, firstLineY2);

                if (distance1 <= distance2)
                {
                    Console.Write(String.Join(", ", firstLineX1, firstLineY1));
                    Console.Write(")");
                    Console.Write("(");
                    Console.Write(String.Join(", ", firstLineX2, firstLineY2));
                }
                else
                {
                    Console.Write(String.Join(", ", firstLineX2, firstLineY2));
                    Console.Write(")");
                    Console.Write("(");
                    Console.Write(String.Join(", ", firstLineX1, firstLineY1));
                }
            }
            else
            {
                double distance1 = GetDistance(secondLineX1, secondLineY1);
                double distance2 = GetDistance(secondLineX2, secondLineY2);

                if (distance1 <= distance2)
                {
                    Console.Write(String.Join(", ", secondLineX1, secondLineY1));
                    Console.Write(")");
                    Console.Write("(");
                    Console.Write(String.Join(", ", secondLineX2, secondLineY2));
                }
                else
                {
                    Console.Write(String.Join(", ", secondLineX2, secondLineY2));
                    Console.Write(")");
                    Console.Write("(");
                    Console.Write(String.Join(", ", secondLineX1, secondLineY1));
                }
            }

            Console.WriteLine(")");
        }

        static double GetLength(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2)
            {
                return Math.Abs(y1) + Math.Abs(y2);
            }
            else if (y1 == y2)
            {
                return Math.Abs(x1) + Math.Abs(x2);
            }

            return Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2);
        }

        static double GetDistance(double x1, double y1)
        {
            return Math.Abs(x1) + Math.Abs(y1);
        }
    }
}
