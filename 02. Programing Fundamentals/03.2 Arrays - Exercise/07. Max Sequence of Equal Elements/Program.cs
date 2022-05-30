using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arraysOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int longestSequence = 1;
            int longestIndex = 0;

            for (int i = 0; i < arraysOfNumbers.Length - 1; i++)
            {
                if (arraysOfNumbers[i] == arraysOfNumbers[i + 1])
                {
                    counter++;
                    if (counter > longestSequence)
                    {
                        longestSequence = counter;
                        longestIndex = i;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < longestSequence; i++)
            {
                Console.Write(arraysOfNumbers[longestIndex] + " ");
            }
        }
    }
}
