using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            decimal sumNumbers = 0;

            for (int currNum = 1; currNum <= numCount; currNum++)
            {
                decimal num = decimal.Parse(Console.ReadLine());
                sumNumbers += num;
            }

            Console.WriteLine(sumNumbers);
        }
    }
}
