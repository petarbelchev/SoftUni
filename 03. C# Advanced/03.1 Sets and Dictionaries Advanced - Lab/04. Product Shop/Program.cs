using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ProdSho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodShops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] shopData = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = shopData[0];
                string product = shopData[1];
                double productPrice = double.Parse(shopData[2]);

                if (foodShops.ContainsKey(shopName))
                {
                    foodShops[shopName].Add(product, productPrice);
                }
                else
                {
                    foodShops[shopName] = new Dictionary<string, double>();
                    foodShops[shopName][product] = productPrice;
                }

                input = Console.ReadLine();
            }

            foreach (var (shop, product) in foodShops.OrderBy(name => name.Key))
            {
                Console.WriteLine($"{shop}->");
                foreach (var kvp in product)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
