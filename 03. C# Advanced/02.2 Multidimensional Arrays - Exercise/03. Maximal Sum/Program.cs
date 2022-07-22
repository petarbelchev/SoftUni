using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsCols[0], rowsCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRowValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRowValues[col];
                }
            }

            int[,] bestMatrix = new int[3, 3];
            int bestMatrixSum = 0;
            int[,] testMatrix = new int[3, 3];
            int testMatrixSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    for (int testRow = 0; testRow < testMatrix.GetLength(0); testRow++)
                    {
                        for (int testCol = 0; testCol < testMatrix.GetLength(1); testCol++)
                        {
                            testMatrix[testRow, testCol] = matrix[row + testRow, col + testCol];

                            testMatrixSum += testMatrix[testRow, testCol];
                        }
                    }

                    if (testMatrixSum > bestMatrixSum)
                    {
                        bestMatrixSum = testMatrixSum;

                        for (int testMatrixRow = 0; testMatrixRow < testMatrix.GetLength(0); testMatrixRow++)
                        {
                            for (int testMatrixCol = 0; testMatrixCol < testMatrix.GetLength(1); testMatrixCol++)
                            {
                                bestMatrix[testMatrixRow, testMatrixCol] = testMatrix[testMatrixRow, testMatrixCol];
                            }
                        }
                    }

                    testMatrixSum = 0;
                }
            }

            Console.WriteLine($"Sum = {bestMatrixSum}");

            for (int row = 0; row < bestMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bestMatrix.GetLength(1); col++)
                {
                    Console.Write(bestMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
