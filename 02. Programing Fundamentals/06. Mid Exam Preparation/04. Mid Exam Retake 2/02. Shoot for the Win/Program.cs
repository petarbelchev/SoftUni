using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            int shotCount = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < targets.Count && targets[index] != -1)
                {
                    int targetValue = targets[index];

                    targets[index] = -1;

                    shotCount++;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > targetValue)
                            {
                                targets[i] -= targetValue;
                            }
                            else
                            {
                                targets[i] += targetValue;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.Write($"Shot targets: {shotCount} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
