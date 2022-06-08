using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            PrintMatrix(rowsAndCols);
        }

        static void PrintMatrix(int rowsAndCols)
        {
            for (int row = 1; row <= rowsAndCols; row++)
            {
                for (int col = 1; col <= rowsAndCols; col++)
                {
                    Console.Write(rowsAndCols + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
