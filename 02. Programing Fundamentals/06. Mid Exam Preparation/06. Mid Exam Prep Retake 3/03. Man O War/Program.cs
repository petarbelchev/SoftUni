using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> warShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Retire")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (cmdArgs[0])
                {
                    case "Fire":

                        int index = int.Parse(cmdArgs[1]);

                        if (index < 0 || index >= warShip.Count)
                        {
                            break;
                        }

                        int damage = int.Parse(cmdArgs[2]);

                        warShip[index] -= damage;

                        if (warShip.ElementAt(int.Parse(cmdArgs[1])) <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");

                            return;
                        }

                        break;

                    case "Defend":

                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);
                        damage = int.Parse(cmdArgs[3]);

                        if (startIndex >= 0
                            && startIndex < pirateShip.Count
                            && endIndex >= 0
                            && endIndex < pirateShip.Count)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");

                                    return;
                                }
                            }
                        }

                        break;

                    case "Repair":

                        index = int.Parse(cmdArgs[1]);
                        int health = int.Parse(cmdArgs[2]);

                        if (index < 0 || index >= pirateShip.Count)
                        {
                            break;
                        }

                        pirateShip[index] += health;

                        if (pirateShip[index] > maxHealth)
                        {
                            pirateShip[index] = maxHealth;
                        }

                        break;

                    case "Status":

                        int sectionsCounter = 0;

                        foreach (var section in pirateShip)
                        {
                            if (section < maxHealth * 0.2)
                            {
                                sectionsCounter++;
                            }
                        }

                        Console.WriteLine($"{sectionsCounter} sections need repair.");

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
