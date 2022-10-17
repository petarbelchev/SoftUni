using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ratioOfWater = new Dictionary<string, double>()
            {
                { "Croissant", 50 },
                { "Muffin", 40 },
                { "Baguette", 30 },
                { "Bagel", 20 }
            };

            var bakedProducts = new Dictionary<string, int>();

            Queue<double> waterQty = new Queue<double>(Console.ReadLine()
                .Split()
                .Select(x => double.Parse(x))
                .ToList());

            Stack<double> flourQty = new Stack<double>(Console.ReadLine()
                .Split()
                .Select(x => double.Parse(x))
                .ToList());

            while (waterQty.Count > 0 && flourQty.Count > 0)
            {
                double water = waterQty.Dequeue();
                double flour = flourQty.Pop();

                double currRatio = (water * 100) / (water + flour);

                string currProduct = ratioOfWater.FirstOrDefault(p => p.Value == currRatio).Key;

                if (currProduct != null)
                {
                    if (!bakedProducts.ContainsKey(currProduct))
                    {
                        bakedProducts[currProduct] = 0;
                    }

                    bakedProducts[currProduct]++;
                }
                else
                {
                    flour -= water;
                    flourQty.Push(flour);

                    if (!bakedProducts.ContainsKey("Croissant"))
                    {
                        bakedProducts["Croissant"] = 0;
                    }

                    bakedProducts["Croissant"]++;
                }
            }

            foreach (var product in bakedProducts.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            string waterLeft = waterQty.Count == 0 ? "None" : string.Join(", ", waterQty);

            Console.WriteLine($"Water left: " + waterLeft);

            string flourLeft = flourQty.Count == 0 ? "None" : string.Join(", ", flourQty);

            Console.WriteLine($"Flour left: " + flourLeft);
        }
    }
}
