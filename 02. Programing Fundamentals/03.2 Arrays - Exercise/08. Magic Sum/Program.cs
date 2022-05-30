using System;
using System.Linq;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumResult = int.Parse(Console.ReadLine());

            for (int firstElement = 0; firstElement < arrayOfNumbers.Length - 1; firstElement++)
            {
                for (int secondElement = firstElement + 1; secondElement < arrayOfNumbers.Length; secondElement++)
                {
                    if (arrayOfNumbers[firstElement] + arrayOfNumbers[secondElement] == sumResult)
                    {
                        Console.WriteLine($"{arrayOfNumbers[firstElement]} {arrayOfNumbers[secondElement]}");
                    }
                }
            }
        }
    }
}
