using System;

namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberA = Math.Abs(Math.Round(double.Parse(Console.ReadLine()), 6));
            double numberB = Math.Abs(Math.Round(double.Parse(Console.ReadLine()), 6));

            bool isEqual = numberA - numberB <= 0.000001;

            Console.WriteLine(isEqual);
        }
    }
}
