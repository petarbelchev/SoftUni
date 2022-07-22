using System;
using System.Linq;
using System.Text;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowChars = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowChars[col];
                }
            }

            if (n > 0)
            {
                string[] coordinatesOfBombs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string coordinates in coordinatesOfBombs)
                {
                    int row = int.Parse(coordinates.Split(',')[0]);
                    int col = int.Parse(coordinates.Split(',')[1]);
                    int bombPower = matrix[row, col];

                    for (int currRow = row - 1; currRow <= row + 1; currRow++)
                    {
                        if (currRow >= 0 && currRow < matrix.GetLength(0))
                        {
                            for (int currCol = col - 1; currCol <= col + 1; currCol++)
                            {
                                if (currCol >= 0 && currCol < matrix.GetLength(1))
                                {
                                    if (matrix[currRow, currCol] > 0 && bombPower > 0)
                                    {
                                        matrix[currRow, currCol] -= bombPower;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                    sb.Append(matrix[row,col] + " ");
                }
                sb.AppendLine();
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
