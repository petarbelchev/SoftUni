using System;

namespace _10._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            for (int i = multiplier; i <= 10; i++)
            {
                int result = num * i;
                Console.WriteLine($"{num} X {i} = {result}");
            }

            if (multiplier > 10)
            {
                int result = num * multiplier;
                Console.WriteLine($"{num} X {multiplier} = {result}");
            }
        }
    }
}
