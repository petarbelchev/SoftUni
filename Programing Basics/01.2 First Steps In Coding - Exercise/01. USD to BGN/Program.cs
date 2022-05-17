using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usdCount = double.Parse(Console.ReadLine());
            double bgnCount = usdCount * 1.79549;
            Console.WriteLine(bgnCount);
        }
    }
}
