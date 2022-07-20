using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesOnTheBox = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int capacityOfSingleRack = int.Parse(Console.ReadLine());

            if (capacityOfSingleRack == 0)
            {
                return;
            }

            Stack<int> stack = new Stack<int>(clothesOnTheBox);

            int racksCounter = 1;
            int currRackCapLeft = capacityOfSingleRack;

            while (stack.Count > 0)
            {
                if (currRackCapLeft >= stack.Peek())
                {
                    currRackCapLeft -= stack.Pop();
                }
                else
                {
                    racksCounter++;
                    currRackCapLeft = capacityOfSingleRack;
                }
            }

            Console.WriteLine(racksCounter);
        }
    }
}
