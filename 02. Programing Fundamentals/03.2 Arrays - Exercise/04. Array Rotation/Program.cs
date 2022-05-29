using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] rotatedArray = new int[arrayOfNumbers.Length];

            int rotationsCount = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotationsCount; rotation++)
            {
                for (int i = 0; i < arrayOfNumbers.Length - 1; i++)
                {
                    rotatedArray[i] = arrayOfNumbers[i + 1];
                }
                rotatedArray[rotatedArray.Length - 1] = arrayOfNumbers[0];

                for (int i = 0; i < rotatedArray.Length; i++)
                {
                    arrayOfNumbers[i] = rotatedArray[i];
                }
            }

            foreach (int number in arrayOfNumbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
