using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Blacksmith
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> swords = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                CheckAndMadeSword(swords, steel, carbon);                
            }

            if (swords.Count == 0)
                Console.WriteLine("You did not have enough resources to forge a sword.");
            else if (swords.Count > 0)
            {
                int swordsCount = swords.Select(sword => sword.Value).Sum();
                Console.WriteLine($"You have forged {swordsCount} swords.");
            }

            if (steel.Count == 0) Console.WriteLine("Steel left: none");
            else Console.WriteLine("Steel left: " + string.Join(", ", steel));

            if (carbon.Count == 0) Console.WriteLine("Carbon left: none");
            else Console.WriteLine("Carbon left: " + string.Join(", ", carbon));

            if (swords.Count > 0)
                foreach (var sword in swords.OrderBy(sword => sword.Key))
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
        }

        private static void CheckAndMadeSword(Dictionary<string, int> swords, Queue<int> steel, Stack<int> carbon)
        {
            int currSteel = steel.Dequeue();
            int currCarbon = carbon.Pop();
            int sum = currCarbon + currSteel;

            if (sum == 70)
            {
                if (swords.ContainsKey("Gladius") == false)
                    swords.Add("Gladius", 0);

                swords["Gladius"]++;
            }
            else if (sum == 80)
            {
                if (swords.ContainsKey("Shamshir") == false)
                    swords.Add("Shamshir", 0);

                swords["Shamshir"]++;
            }
            else if (sum == 90)
            {
                if (swords.ContainsKey("Katana") == false)
                    swords.Add("Katana", 0);

                swords["Katana"]++;
            }
            else if (sum == 110)
            {
                if (swords.ContainsKey("Sabre") == false)
                    swords.Add("Sabre", 0);

                swords["Sabre"]++;
            }
            else if (sum == 150)
            {
                if (swords.ContainsKey("Broadsword") == false)
                    swords.Add("Broadsword", 0);

                swords["Broadsword"]++;
            }
            else
            {
                currCarbon += 5;
                carbon.Push(currCarbon);
            }
        }
    }
}
