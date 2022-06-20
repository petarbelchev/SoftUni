using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] initialDrumSet = new int[drumSet.Count];

            drumSet.CopyTo(initialDrumSet);

            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= hitPower;

                    if (drumSet[i] <= 0)
                    {
                        if (savings >= initialDrumSet[i] * 3)
                        {
                            savings -= initialDrumSet[i] * 3;
                            drumSet[i] = initialDrumSet[i];
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSet.FindAll(x => x > 0)));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
