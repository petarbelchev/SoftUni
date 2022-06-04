using System;

namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            PrintTriangle(length);
        }

        static void PrintTriangle(int length)
        {
            for (int row = 1; row <= length; row++)
            {
                int num = 1;

                for (int col = length - row; col < length; col++)
                {
                    Console.Write(num + " ");
                    num++;
                }
                Console.WriteLine();
            }

            for (int row = 1; row < length; row++)
            {
                int num = 1;

                for (int col = row; col < length; col++)
                {
                    Console.Write(num + " ");
                    num++;
                }
                Console.WriteLine();
            }
        }
    }
}
