using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int numCondensation = 0; numCondensation < arrayOfNumbers.Length - 1; numCondensation++)
            {
                for (int currIndex = 0; currIndex < arrayOfNumbers.Length - 1; currIndex++)
                {
                    arrayOfNumbers[currIndex] = arrayOfNumbers[currIndex] + arrayOfNumbers[currIndex + 1];
                }
            }

            Console.WriteLine(arrayOfNumbers[0]);
        }
    }
}
