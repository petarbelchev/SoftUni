using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] firstRowPart1 = new int[inputArr.Length / 4];

            for (int i = 0; i < firstRowPart1.Length; i++)
            {
                firstRowPart1[i] = inputArr[i];
            }

            int[] firstRowPart2 = new int[inputArr.Length / 4];

            for (int i = 0; i < firstRowPart2.Length; i++)
            {
                firstRowPart2[i] = inputArr[i + 3 * firstRowPart1.Length];
            }

            Array.Reverse(firstRowPart1);
            Array.Reverse(firstRowPart2);

            int[] secondRow = new int[inputArr.Length / 2];

            for (int i = 0; i < secondRow.Length; i++)
            {
                secondRow[i] = inputArr[i + firstRowPart1.Length];
            }

            for (int i = 0; i < secondRow.Length / 2; i++)
            {
                secondRow[i] += firstRowPart1[i];
            }

            for (int i = firstRowPart2.Length; i < secondRow.Length; i++)
            {
                secondRow[i] += firstRowPart2[i - firstRowPart2.Length];
            }

            Console.WriteLine(String.Join(" ", secondRow));
        }
    }
}
