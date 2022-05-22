using System;

namespace _07._Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row <= n; row++)
            {
                for (int spacers = row; spacers < n; spacers++)
                {
                    Console.Write(" ");
                }

                for (int stars = row; stars > 0; stars--)
                {
                    Console.Write("*");
                }

                Console.Write(" | ");

                for (int stars = row; stars > 0; stars--)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
