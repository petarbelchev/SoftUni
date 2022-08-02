using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var plants = new Dictionary<string, PlantInfo>();
        int nLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < nLines; i++)
        {
            string[] plantData = Console.ReadLine()
                .Split("<->", StringSplitOptions.RemoveEmptyEntries);
            string name = plantData[0];
            int rarity = int.Parse(plantData[1]);
            if (!plants.ContainsKey(name))
            {
                plants[name] = new PlantInfo();
            }
            plants[name].Rarity = rarity;
        }
        string cmd = Console.ReadLine();
        while (cmd != "Exhibition")
        {
            string[] cmdArgs = cmd.Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string plant = cmdArgs[1].Split(" - ")[0];
            if (plants.ContainsKey(plant))
            {
                switch (cmdArgs[0])
                {
                    case "Rate":
                        int rating = int.Parse(cmdArgs[1].Split(" - ")[1]);
                        plants[plant].Ratings.Add(rating);
                        break;
                    case "Update":
                        int newRarity = int.Parse(cmdArgs[1].Split(" - ")[1]);
                        plants[plant].Rarity = newRarity;
                        break;
                    case "Reset":
                        plants[plant].Ratings.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            cmd = Console.ReadLine();
        }
        Console.WriteLine("Plants for the exhibition:");
        foreach (var plant in plants)
        {
            double avRating = 0;
            if (plant.Value.Ratings.Count > 0)
                avRating = plant.Value.Ratings.Average();
            Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {avRating:f2}");
        }
    }
}

class PlantInfo
{
    public int Rarity { get; set; }
    public List<int> Ratings { get; set; } = new List<int>();
}