using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        var wardrobe = new Dictionary<string, Dictionary<string, int>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

            string color = input[0];

            if (!wardrobe.ContainsKey(color))
                wardrobe.Add(color, new Dictionary<string, int>());

            for (int j = 1; j < input.Length; j++)
            {
                string currItem = input[j];

                if (wardrobe[color].ContainsKey(currItem))
                    wardrobe[color][currItem]++;
                else
                    wardrobe[color].Add(currItem, 1);
            }
        }

        string[] lookedItem = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var (color, items) in wardrobe)
        {
            Console.WriteLine($"{color} clothes:");
            foreach (var item in items)
            {
                if (color == lookedItem[0] && item.Key == lookedItem[1])
                    Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                else
                    Console.WriteLine($"* {item.Key} - {item.Value}");
            }
        }
    }
}
