using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double facFirstNum = GetFactorial(firstNum);
            double facSecondNum = GetFactorial(secondNum);

            Console.WriteLine($"{(facFirstNum / facSecondNum):f2}");
        }

        static double GetFactorial(double number)
        {
            for (double i = number - 1; i > 1; i--)
            {
                number *= i;
            }

            return number;
        }
    }
}
