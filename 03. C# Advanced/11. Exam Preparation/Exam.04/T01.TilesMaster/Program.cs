using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var locations = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 }
            };

            var whiteTiles = new Stack<int>();

            var whiteTilesData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var item in whiteTilesData)
                whiteTiles.Push(item);

            var greyTiles = new Queue<int>();

            var greyTilesData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var item in greyTilesData)
                greyTiles.Enqueue(item);

            var decoratedLocations = new Dictionary<string, int>();

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int white = whiteTiles.Pop();
                int grey = greyTiles.Dequeue();

                var currTile = white + grey;

                if (white == grey)
                {
                    var currLocation = locations
                        .FirstOrDefault(t => t.Value == white + grey).Key;

                    if (currLocation != null)
                    {
                        if (!decoratedLocations.ContainsKey(currLocation))
                            decoratedLocations.Add(currLocation, 0);

                        decoratedLocations[currLocation]++;
                    }
                    else
                    {
                        if (!decoratedLocations.ContainsKey("Floor"))
                            decoratedLocations.Add("Floor", 0);

                        decoratedLocations["Floor"]++;
                    }
                }
                else
                {
                    white /= 2;
                    whiteTiles.Push(white);
                    greyTiles.Enqueue(grey);
                }
            }

            if (whiteTiles.Count == 0)
                Console.WriteLine("White tiles left: none");
            else
                Console.WriteLine("White tiles left: " + string.Join(", ", whiteTiles));

            if (greyTiles.Count == 0)
                Console.WriteLine("Grey tiles left: none");
            else
                Console.WriteLine("Grey tiles left: " + string.Join(", ", greyTiles));

            foreach (var location in decoratedLocations
                                        .OrderByDescending(l => l.Value)
                                        .ThenBy(t => t.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
