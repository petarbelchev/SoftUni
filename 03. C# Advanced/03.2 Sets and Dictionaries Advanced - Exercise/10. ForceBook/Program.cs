using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sides = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] inputData = input
                    .Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" | "))
                {
                    string currSide = inputData[0];
                    string currUser = inputData[1];

                    if (sides.Any(side => side.Value.Contains(currUser)))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!sides.ContainsKey(currSide))
                    {
                        sides[currSide] = new HashSet<string>();
                    }

                    sides[currSide].Add(currUser);
                }
                else if (input.Contains(" -> "))
                {
                    string currSide = inputData[1];
                    string currUser = inputData[0];

                    if (sides.Any(s => s.Value.Contains(currUser) && s.Key != currSide))
                    {
                        string sideUserIn = sides.Where(s => s.Value.Contains(currUser) && s.Key != currSide).Select(u => u.Key).First();

                        sides[sideUserIn].Remove(currUser);

                        if (!sides.ContainsKey(currSide))
                        {
                            sides.Add(currSide, new HashSet<string>());
                        }

                        sides[currSide].Add(currUser);

                        Console.WriteLine($"{currUser} joins the {currSide} side!");
                    }
                    else
                    {
                        if (!sides.ContainsKey(currSide))
                        {
                            sides.Add(currSide, new HashSet<string>());
                        }

                        sides[currSide].Add(currUser);

                        Console.WriteLine($"{currUser} joins the {currSide} side!");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides
                .Where(f => f.Value.Count > 0)
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
