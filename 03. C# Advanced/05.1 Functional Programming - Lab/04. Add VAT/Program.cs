using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Func<double, double> addVAT = price => price += price * 0.2;

        double[] prices = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(price => addVAT(price))
            .ToArray();

        Action<double> PrintOnTheConsole = price => Console.WriteLine($"{price:f2}");

        Array.ForEach(prices, PrintOnTheConsole);
    }
}
