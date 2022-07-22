using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4._MatrixShuffl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[rowsCols[0], rowsCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currRowValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRowValues[col];
                }
            }

            string cmdArgs = Console.ReadLine();

            Regex cmdChecker = new Regex(@"^\s*(?<cmd>swap)\s+(?<row1>\d+)\s+(?<col1>\d+)\s+(?<row2>\d+)\s+(?<col2>\d+)\s*$");

            while (cmdArgs != "END")
            {
                Match match = cmdChecker.Match(cmdArgs);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid input!");
                    cmdArgs = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(match.Groups["row1"].Value);
                int col1 = int.Parse(match.Groups["col1"].Value);
                int row2 = int.Parse(match.Groups["row2"].Value);
                int col2 = int.Parse(match.Groups["col2"].Value);

                if (row1 < 0 || row1 >= matrix.GetLength(0)
                    || col1 < 0 || col1 >= matrix.GetLength(1)
                    || row2 < 0 || row2 >= matrix.GetLength(0)
                    || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    cmdArgs = Console.ReadLine();
                    continue;
                }

                string firstCoordinatesValue = matrix[row1, col1];
                matrix[row1,col1] = matrix[row2,col2];
                matrix[row2,col2] = firstCoordinatesValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                cmdArgs = Console.ReadLine();
            }
        }
    }
}
