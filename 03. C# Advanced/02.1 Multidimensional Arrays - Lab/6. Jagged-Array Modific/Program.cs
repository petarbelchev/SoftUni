using System;
using System.Linq;

namespace _6._Jagged_Array_Modific
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRowValues = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();

                matrix[row] = new int[currRowValues.Length];

                for (int col = 0; col < currRowValues.Length; col++)
                {
                    matrix[row][col] = currRowValues[col];
                }
            }
            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] cmdArgs = cmd.Split();

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= 0 && row < matrix.GetLength(0) 
                    && col >= 0 && col < matrix[row].Length)
                {
                    if (cmdArgs[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (cmdArgs[0] == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid coordinates");
                }

                cmd = Console.ReadLine();
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }
    }
}
