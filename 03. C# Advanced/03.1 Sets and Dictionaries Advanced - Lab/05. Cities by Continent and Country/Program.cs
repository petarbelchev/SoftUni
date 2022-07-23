using System;
using System.Collections.Generic;

namespace _05._CitCoCo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfCities = int.Parse(Console.ReadLine());
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < countOfCities; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(country))
                    {
                        continents[continent][country].Add(city);
                    }
                    else
                    {
                        continents[continent][country] = new List<string>() { city };
                    }
                }
                else
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                    continents[continent].Add(country, new List<string>() { city });
                }
            }

            foreach (var (continent, country) in continents)
            {
                Console.WriteLine($"{continent}:");
                foreach (var kvp in country)
                {
                    Console.WriteLine($"  {kvp.Key} -> " + string.Join(", ", kvp.Value));
                }
            }
        }
    }
}
