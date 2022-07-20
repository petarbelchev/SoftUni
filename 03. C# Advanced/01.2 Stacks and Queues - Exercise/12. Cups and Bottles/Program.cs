using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> cupsQueue = new Queue<int>(cups);

            int[] bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> bottlesStack = new Stack<int>(bottles);

            int wastedWater = 0;

            while (cupsQueue.Count > 0 && bottlesStack.Count > 0)
            {
                int currBottle = bottlesStack.Pop();

                if (currBottle >= cupsQueue.Peek())
                {
                    wastedWater += currBottle - cupsQueue.Dequeue();
                }
                else
                {
                    var newCupsQueue = cupsQueue.ToArray();
                    newCupsQueue[0] -= currBottle;
                    cupsQueue = new Queue<int>(newCupsQueue);
                }
            }

            if (cupsQueue.Count > 0 && bottlesStack.Count == 0)
            {
                Console.Write($"Cups: ");
                Console.WriteLine(string.Join(' ', cupsQueue));
            }
            else
            {
                Console.Write($"Bottles: ");
                Console.WriteLine(string.Join(' ', bottlesStack));
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
