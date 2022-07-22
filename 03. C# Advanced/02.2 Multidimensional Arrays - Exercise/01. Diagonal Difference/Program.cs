using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] square = new int[squareSize, squareSize];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                int[] currRowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < square.GetLength(1); col++)
                {
                    square[row, col] = currRowValues[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                sumPrimaryDiagonal += square[i, i];
            }

            int sumSecondaryDiagonal = 0;
            int currCol = square.GetLength(1) - 1;
            for (int row = 0; row < square.GetLength(0); row++)
            {
                sumSecondaryDiagonal += square[row, currCol];
                currCol--;
            }

            int difference = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}
