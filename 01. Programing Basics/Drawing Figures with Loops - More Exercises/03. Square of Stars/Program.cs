using System;

namespace _03._Square_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = '*';
            string forPrint = null;

            for (int i = 1; i <= n; i++)
            {
                forPrint += symbol + " ";
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(forPrint);
            }
        }
    }
}
