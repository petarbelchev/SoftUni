using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeinе = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Queue<int> energy = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            int drankCaffeinе = 0;
            const int maxCaffeinе = 300;

            while (caffeinе.Count > 0 && energy.Count > 0)
            {
                int currCaffeinе = caffeinе.Pop();
                int currEnergy = energy.Dequeue();
                int currSum = currCaffeinе * currEnergy;

                if (drankCaffeinе + currSum <= maxCaffeinе)
                    drankCaffeinе += currSum;
                else
                {
                    energy.Enqueue(currEnergy);
                    drankCaffeinе -= 30;

                    if (drankCaffeinе < 0)
                        drankCaffeinе = 0;
                }
            }

            Console.WriteLine((energy.Count == 0) ?
                "At least Stamat wasn't exceeding the maximum caffeine." :
                "Drinks left: " + string.Join(", ", energy));

            Console.WriteLine($"Stamat is going to sleep with {drankCaffeinе} mg caffeine.");
        }
    }
}
