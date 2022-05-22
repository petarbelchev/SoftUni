using System;

namespace _04._Triangle_of_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char symbol = '$';
            string forPrint = null;

            for (int i = 1; i <= n; i++)
            {
                forPrint += symbol + " ";
                Console.WriteLine(forPrint);
            }
        }
    }
}
