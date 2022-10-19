using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 150 },
                {"Green salad", 250 },
                {"Chocolate cake", 300 },
                {"Lobster", 400 }
            };

            var cookedDishes = new Dictionary<string, int>();

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int counterNewDishes = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int ingredient = ingredients.Dequeue();

                if (ingredient == 0)
                    continue;

                int fresh = freshness.Pop();
                int value = ingredient * fresh;

                string dish = dishes.FirstOrDefault(d => d.Value == value).Key;

                if (dish != null)
                {
                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 0);
                        counterNewDishes++;
                    }

                    cookedDishes[dish]++;
                }
                else
                {
                    ingredient += 5;
                    ingredients.Enqueue(ingredient);
                }
            }

            if (counterNewDishes == 4)
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            else
                Console.WriteLine("You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");

            foreach (var dish in cookedDishes.OrderBy(d => d.Key))
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
        }
    }
}
