using System;

namespace _04._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPerKilo = double.Parse(Console.ReadLine());
            double fruitsPerKilo = double.Parse(Console.ReadLine());
            int vegetablesKilograms = int.Parse(Console.ReadLine());
            int fruitsKilograms = int.Parse(Console.ReadLine());

            double income = ((vegetablesPerKilo * vegetablesKilograms) + (fruitsPerKilo * fruitsKilograms)) / 1.94;
            Console.WriteLine($"{income:f2}");
        }
    }
}
