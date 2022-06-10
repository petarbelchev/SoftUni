using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());
            double num4 = double.Parse(Console.ReadLine());

            double moves1 = GetMovesCount(num1, num2);
            double moves2 = GetMovesCount(num3, num4);

            Console.Write("(");

            if (moves1 <= moves2)
            {
                Console.Write(String.Join(", ", num1, num2));
            }
            else
            {
                Console.Write(String.Join(", ", num3, num4));
            }

            Console.WriteLine(")");
        }

        static double GetMovesCount(double num1, double num2)
        {
            return Math.Abs(num1) + Math.Abs(num2);
        }
    }
}
