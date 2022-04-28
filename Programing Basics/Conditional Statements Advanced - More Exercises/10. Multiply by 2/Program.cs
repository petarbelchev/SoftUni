using System;

namespace _10._Multiply_by_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double a = double.Parse(Console.ReadLine());

                if (a >= 0)
                {
                    Console.WriteLine($"Result: {a * 2:f2}");
                }
                else
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
            }
        }
    }
}
