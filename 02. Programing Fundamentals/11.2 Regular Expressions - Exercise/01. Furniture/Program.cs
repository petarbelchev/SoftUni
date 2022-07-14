using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+(?:\.\d+)?)!(?<qty>\d+)");

            List<string> furnitures = new List<string>();

            double totalIncome = 0;

            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int qty = int.Parse(match.Groups["qty"].Value);
                    
                    furnitures.Add(name);
                    totalIncome += price * qty;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (furnitures.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
            }
            Console.WriteLine($"Total money spend: {totalIncome:f2}");
        }
    }
}
