using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int sumYield = 0;
            int daysCount = 0;

            while (startingYield > 99)
            {
                int currYield = startingYield;
                currYield -= 26;
                sumYield += currYield;
                daysCount++;
                startingYield -= 10;
            }

            if (sumYield >= 26)
            {
                sumYield -= 26;
            }
            else
            {
                sumYield = 0;
            }

            Console.WriteLine(daysCount);
            Console.WriteLine(sumYield);
        }
    }
}
