using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLoot = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Yohoho!")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string mainCmd = cmdArgs[0];

                switch (mainCmd)
                {
                    case "Loot":
                        for (int i = 1; i < cmdArgs.Length; i++)
                        {
                            if (!initialLoot.Contains(cmdArgs[i]))
                            {
                                initialLoot.Insert(0, cmdArgs[i]);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(cmdArgs[1]);
                        if (index < 0 || index >= initialLoot.Count)
                        {
                            break;
                        }
                        else
                        {
                            initialLoot.Add(initialLoot[index]);
                            initialLoot.RemoveAt(index);
                        }
                        break;

                    case "Steal":
                        int count = int.Parse(cmdArgs[1]);

                        if (count > initialLoot.Count)
                        {
                            count = initialLoot.Count;
                        }

                        List<string> output = new List<string>();

                        for (int i = initialLoot.Count - count; i <= initialLoot.Count - 1; i++)
                        {
                            output.Add(initialLoot[i]);
                        }

                        Console.WriteLine(string.Join(", ", output));

                        initialLoot.RemoveRange(initialLoot.Count - count, count);

                        break;
                }

                cmd = Console.ReadLine();
            }

            if (initialLoot.Count > 0)
            {
                List<int> elLength = new List<int>();

                foreach (string loot in initialLoot)
                {
                    elLength.Add(loot.Length);
                }

                double avGain = (double)elLength.Sum() / elLength.Count;

                Console.WriteLine($"Average treasure gain: {avGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
