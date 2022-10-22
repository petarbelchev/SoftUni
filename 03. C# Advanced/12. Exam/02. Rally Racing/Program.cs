using System;
using System.Collections.Generic;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            string carNumber = Console.ReadLine();
            List<int> tunel = new List<int>();
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] rowData = string.Join("", Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    .ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'T')
                    {
                        tunel.Add(row);
                        tunel.Add(col);
                    }
                }
            }

            matrix[startRow, startCol] = 'C';
            int kilometers = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "End")
                {
                    Console.WriteLine($"Racing car {carNumber} DNF.");
                    break;
                }

                matrix[startRow, startCol] = '.';

                if (direction == "up")
                    startRow--;
                else if (direction == "down")
                    startRow++;
                else if (direction == "left")
                    startCol--;
                else if (direction == "right")
                    startCol++;

                if (matrix[startRow, startCol] == 'T')
                {
                    matrix[startRow, startCol] = '.';

                    if (startRow == tunel[0])
                    {
                        startRow = tunel[2];
                        startCol = tunel[3];
                    }
                    else
                    {
                        startRow = tunel[0];
                        startCol = tunel[1];
                    }

                    kilometers += 30;
                }
                else if (matrix[startRow, startCol] == '.')
                {
                    kilometers += 10;
                }
                else if (matrix[startRow, startCol] == 'F')
                {
                    kilometers += 10;
                    matrix[startRow, startCol] = 'C';
                    Console.WriteLine($"Racing car {carNumber} finished the stage!");
                    break;
                }

                matrix[startRow, startCol] = 'C';
            }

            Console.WriteLine($"Distance covered {kilometers} km.");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
