using System;

namespace _02._Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectSumSells = int.Parse(Console.ReadLine());
            int cashSells = 0;
            int cashCounter = 0;
            int cardSells = 0;
            int cardCounter = 0;
            int inputSell = 0;
            int counter = 1;

            while (true)
            {
                if (expectSumSells <= 0)
                {
                    Console.WriteLine($"Average CS: {(double)cashSells / cashCounter:f2}");
                    Console.WriteLine($"Average CC: {(double)cardSells / cardCounter:f2}");
                    break;
                }

                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    break;
                }
                else
                {
                    inputSell = int.Parse(input);
                }

                if (counter % 2 == 0 && inputSell >= 10)
                {
                    expectSumSells -= inputSell;
                    cardSells += inputSell;
                    cardCounter++;
                    Console.WriteLine("Product sold!");
                }
                else if (counter % 2 != 0 && inputSell <= 100)
                {
                    expectSumSells -= inputSell;
                    cashSells += inputSell;
                    cashCounter++;
                    Console.WriteLine("Product sold!");
                }
                else
                {
                    Console.WriteLine("Error in transaction!");
                }

                counter++;
            }
        }
    }
}
