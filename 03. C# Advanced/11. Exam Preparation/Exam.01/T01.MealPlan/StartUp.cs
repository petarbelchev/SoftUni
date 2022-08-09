using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] initialMeals = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Meal> meals = GetMealsCalories(initialMeals);

            List<int> dailyCalories = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            while (meals.Count > 0 && dailyCalories.Count > 0)
            {
                if (dailyCalories[0] > meals[0].Calories)
                {
                    dailyCalories[0] -= meals[0].Calories;
                    meals.RemoveAt(0);
                }
                else if (dailyCalories[0] == meals[0].Calories)
                {
                    dailyCalories.RemoveAt(0);
                    meals.RemoveAt(0);
                }
                else if (dailyCalories[0] < meals[0].Calories)
                {
                    meals[0].Calories -= dailyCalories[0];
                    dailyCalories.RemoveAt(0);
                    if (dailyCalories.Count > 0) dailyCalories[0] -= meals[0].Calories;
                    meals.RemoveAt(0);
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {initialMeals.Length} meals.");

                Console.WriteLine("For the next few days, he can eat " + string.Join(", ", dailyCalories) + " calories.");
            }
            else if (dailyCalories.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {initialMeals.Length - meals.Count} meals.");

                Console.WriteLine("Meals left: " + string.Join(", ", meals) + ".");
            }
        }

        static List<Meal> GetMealsCalories(string[] meals)
        {
            var result = new List<Meal>();

            foreach (var meal in meals)
            {
                if (meal == "salad") result.Add(new Meal(meal, 350));
                else if (meal == "soup") result.Add(new Meal(meal, 490));
                else if (meal == "pasta") result.Add(new Meal(meal, 680));
                else if (meal == "steak") result.Add(new Meal(meal, 790));
            }

            return result;
        }
    }

    class Meal
    {
        public Meal(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }
        public string Name { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
