using System;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int wonsCount = 0;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance <= initialEnergy)
                {
                    wonsCount++;
                    initialEnergy -= distance;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonsCount} won battles and {initialEnergy} energy");
                    return;
                }

                if (wonsCount % 3 == 0)
                {
                    initialEnergy += wonsCount;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wonsCount}. Energy left: {initialEnergy}");
        }
    }
}
