using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%(?<name>[A-Z][a-z]+)%[^|%$.]*<(?<product>\w+)>[^|%$.]*\|(?<count>\d+)\|[^|%$.]*(?<price>[1-9][0-9]*(\.\d+)?)\$");

            var costumers = new List<Costumer>();

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string costumer = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double totalPrice = price * count;

                    costumers.Add(new Costumer(costumer, product, totalPrice));
                }

                input = Console.ReadLine();
            }

            double totalIncome = 0;

            foreach (var costumer in costumers)
            {
                Console.WriteLine($"{costumer.Name}: {costumer.Product} - {costumer.TotalPrice:f2}");

                totalIncome += costumer.TotalPrice;
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }

    class Costumer
    {
        public Costumer(string name, string product, double totalPrice)
        {
            Name = name;
            Product = product;
            TotalPrice = totalPrice;
        }

        public string Name { get; set; }
        public string Product { get; set; }
        public double TotalPrice { get; set; }
    }
}
