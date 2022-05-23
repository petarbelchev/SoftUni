using System;

namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal britishPounds = decimal.Parse(Console.ReadLine());
            decimal usDollars = britishPounds * 1.31m;
            Console.WriteLine($"{usDollars:f3}");
        }
    }
}
