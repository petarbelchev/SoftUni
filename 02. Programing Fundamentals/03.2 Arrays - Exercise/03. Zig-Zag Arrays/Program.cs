using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            int[] firstArray = new int[linesCount];
            int[] secondArray = new int[linesCount];

            for (int currLine = 0; currLine < linesCount; currLine++)
            {
                int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (currLine % 2 == 0)
                {
                    firstArray[currLine] = inputNums[0];
                    secondArray[currLine] = inputNums[1];
                }
                else
                {
                    secondArray[currLine] = inputNums[0];
                    firstArray[currLine] = inputNums[1];
                }
            }

            foreach (int number in firstArray)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            foreach (int number in secondArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
