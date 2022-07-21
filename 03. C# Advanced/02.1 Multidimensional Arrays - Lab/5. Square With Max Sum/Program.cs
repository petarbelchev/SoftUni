using System;
using System.Linq;

namespace _5._Square_With_Max_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rolsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[rolsAndCols[0], rolsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRowValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRowValues[col];
                }
            }
            int biggestSum = 0;

            string bestSquare = string.Empty;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > biggestSum)
                    {
                        biggestSum = currSum;
                        bestSquare = $"{matrix[row, col]} {matrix[row, col + 1]}\n{matrix[row + 1, col]} {matrix[row + 1, col + 1]}";
                    }
                }
            }
            Console.WriteLine(bestSquare);
            
            Console.WriteLine(biggestSum);
        }
    }
}
