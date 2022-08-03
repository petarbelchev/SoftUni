using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cities = new Dictionary<string, CitiValues>();

        string cmd = Console.ReadLine();

        while (cmd != "Sail")
        {
            string[] cityData = cmd.Split("||", StringSplitOptions.RemoveEmptyEntries);

            string city = cityData[0];
            int population = int.Parse(cityData[1]);
            int gold = int.Parse(cityData[2]);

            if (!cities.ContainsKey(city))
            {
                cities[city] = new CitiValues();
            }

            cities[city].Population += population;
            cities[city].Gold += gold;

            cmd = Console.ReadLine();
        }
        cmd = Console.ReadLine();

        while (cmd != "End")
        {
            string[] cmdArgs = cmd.Split("=>", StringSplitOptions.RemoveEmptyEntries);
            string town = cmdArgs[1];

            if (cmdArgs[0] == "Plunder")
            {
                int people = int.Parse(cmdArgs[2]);
                int gold = int.Parse(cmdArgs[3]);

                cities[town].Population -= people;
                cities[town].Gold -= gold;
                Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                {
                    cities.Remove(town);
                    Console.WriteLine($"{town} has been wiped off the map!");
                }
            }
            else if (cmdArgs[0] == "Prosper")
            {
                int gold = int.Parse(cmdArgs[2]);
                if (gold >= 0)
                {
                    cities[town].Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                }
                else
                {
                    Console.WriteLine("Gold added cannot be a negative number!");
                }
            }

            cmd = Console.ReadLine();
        }

        if (cities.Count > 0)
        {
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
            }
        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}

class CitiValues
{
    public int Population { get; set; }
    public int Gold { get; set; }
}