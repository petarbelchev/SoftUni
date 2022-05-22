using System;

namespace _01._Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameMovie = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());
            double percent = int.Parse(Console.ReadLine());

            double totalIncome = (days * tickets * priceTicket);
            double totalProfit = totalIncome - (totalIncome * (percent / 100));

            Console.WriteLine($"The profit from the movie {nameMovie} is {totalProfit:f2} lv.");
        }
    }
}
