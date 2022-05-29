using System;
using System.Linq;

namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                bool isGreater = true;

                for (int j = i + 1; j < arrayOfNumbers.Length; j++)
                {
                    if (arrayOfNumbers[i] <= arrayOfNumbers[j])
                    {
                        isGreater = false;
                        break;
                    }
                }

                if (isGreater)
                {
                    Console.Write($"{arrayOfNumbers[i]} ");
                }
            }
        }
    }
}
