using System;
using System.Numerics;

namespace _02._Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = n;

            for (int i = n - 1; i > 1; i--)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
