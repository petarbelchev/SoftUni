using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rowsCount][];

            triangle[0] = new long[1] { 1 };

            for (int row = 1; row < triangle.GetLength(0); row++)
            {
                triangle[row] = new long[triangle[row - 1].Length + 1];
                
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                for (int col = 1; col < triangle[row].Length - 1; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
            }

            for (int row = 0; row < triangle.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', triangle[row]));
            }
        }
    }
}
