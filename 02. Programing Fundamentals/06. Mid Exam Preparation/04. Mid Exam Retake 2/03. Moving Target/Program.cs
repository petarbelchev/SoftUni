using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MovTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string mainCmd = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);

                switch (mainCmd)
                {
                    case "Shoot":
                        int power = int.Parse(cmdArgs[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":
                        int value = int.Parse(cmdArgs[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int radius = int.Parse(cmdArgs[2]);
                        if (IsStrikeMissed(targets, index, radius))
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        else
                        {
                            targets.RemoveRange(index - radius, (radius * 2) + 1);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join("|", targets));
        }

        static bool IsStrikeMissed(List<int> targets, int index, int radius)
        {
            if (index - radius >= 0 && index + radius < targets.Count)
            {
                return false;
            }

            return true;
        }
    }
}
