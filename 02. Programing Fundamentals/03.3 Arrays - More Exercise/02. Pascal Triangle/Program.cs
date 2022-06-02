using System;
using System.Linq;

namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());

            Console.WriteLine("1");

            if (rowsNum == 1)
            {
                return;
            }

            int[] firstArray = new int[2] { 1, 1 };
            Console.WriteLine(String.Join(" ", firstArray));

            if (rowsNum == 2)
            {
                return;
            }
            else
            {
                for (int row = 3; row <= rowsNum; row++)
                {
                    int[] secondArray = new int[firstArray.Length + 1];
                    secondArray[0] = 1;
                    secondArray[secondArray.Length - 1] = 1;

                    for (int i = 1; i < secondArray.Length - 1; i++)
                    {
                        secondArray[i] = firstArray[i] + firstArray[i - 1];
                    }
                    firstArray = secondArray;

                    Console.WriteLine(String.Join(" ", firstArray));
                }
            }
        }
    }
}
