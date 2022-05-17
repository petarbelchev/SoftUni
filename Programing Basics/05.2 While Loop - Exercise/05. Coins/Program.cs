using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double coinSum = 0;

            if (change >= 2)
            {
                coinSum += Math.Floor(change / 2);
                change = Math.Round(change - (Math.Floor(change / 2) * 2), 2);
            }
            if (change >= 1)
            {
                coinSum += Math.Floor(change / 1);
                change = Math.Round(change - (Math.Floor(change / 1) * 1), 2);
            }
            if (change >= 0.5)
            {
                coinSum += Math.Floor(change / 0.5);
                change = Math.Round(change - (Math.Floor(change / 0.5) * 0.5), 2);
            }
            if (change >= 0.2)
            {
                coinSum += Math.Floor(change / 0.2);
                change = Math.Round(change - (Math.Floor(change / 0.2) * 0.2), 2);
            }
            if (change >= 0.1)
            {
                coinSum += Math.Floor(change / 0.1);
                change = Math.Round(change - (Math.Floor(change / 0.1) * 0.1), 2);
            }
            if (change >= 0.05)
            {
                coinSum += Math.Floor(change / 0.05);
                change = Math.Round(change - (Math.Floor(change / 0.05) * 0.05), 2);
            }
            if (change >= 0.02)
            {
                coinSum += Math.Floor(change / 0.02);
                change = Math.Round(change - (Math.Floor(change / 0.02) * 0.02), 2);
            }
            if (change >= 0.01)
            {
                coinSum += Math.Floor(change / 0.01);
                change = Math.Round(change - (Math.Floor(change / 0.01) * 0.01), 2);
            }

            Console.WriteLine(coinSum);
        }
    }
}
