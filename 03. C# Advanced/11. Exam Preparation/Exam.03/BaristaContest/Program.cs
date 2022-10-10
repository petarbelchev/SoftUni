using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var drinks = new Dictionary<string, int>()
            {
                { "Cortado", 50 },
                { "Espresso", 75},
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 }
            };

            var madedDrings = new Dictionary<string, int>();

            var coffeeInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> coffeeQty = new Stack<int>();

            foreach (var input in coffeeInput.Reverse())
            {
                coffeeQty.Push(input);
            }

            var milkInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> milkQty = new Stack<int>();

            foreach (var input in milkInput)
            {
                milkQty.Push(input);
            }

            while (coffeeQty.Count > 0 && milkQty.Count > 0)
            {
                int coffee = coffeeQty.Pop();
                int milk = milkQty.Pop();

                string posibleDrink = drinks
                    .FirstOrDefault(d => d.Value == coffee + milk)
                    .Key;

                if (posibleDrink != null)
                {
                    if (!madedDrings.ContainsKey(posibleDrink))
                    {
                        madedDrings.Add(posibleDrink, 0);
                    }

                    madedDrings[posibleDrink]++;
                }
                else
                {
                    milk -= 5;
                    milkQty.Push(milk);
                }
            }

            if (coffeeQty.Count == 0 && milkQty.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQty.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine("Coffee left: " + string.Join(", ", coffeeQty));
            }

            if (milkQty.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Milk left: " + string.Join(", ", milkQty));
            }

            foreach (var drink in madedDrings
                                        .OrderBy(d => d.Value)
                                        .ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
