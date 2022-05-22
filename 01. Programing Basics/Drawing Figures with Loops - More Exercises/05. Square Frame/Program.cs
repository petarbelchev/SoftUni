using System;

namespace _05._Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string plus = "+";
            string minus = "-";
            string line = "|";

            Console.Write(plus + " ");

            for (int i = 1; i <= n-2; i++)
            {
                Console.Write(minus + " ");
            }

            Console.WriteLine(plus + " ");

            for (int i = 1; i <= n-2; i++)
            {
                Console.Write(line + " ");

                for (int k = 1; k <= n-2; k++)
                {
                    Console.Write(minus + " ");
                }

                Console.WriteLine(line + " ");
            }

            Console.Write(plus + " ");

            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(minus + " ");
            }

            Console.WriteLine(plus + " ");
        }
    }
}
