using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numCountToEnqueue = NSX[0];
            int numCountToDequeue = NSX[1];
            int numToPeek = NSX[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numCountToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            if (queue.Count > numCountToDequeue)
            {
                for (int i = 1; i <= numCountToDequeue; i++)
                {
                    queue.Dequeue();
                }
            }
            else
            {
                queue.Clear();
                Console.WriteLine("0");
                return;
            }

            if (queue.Contains(numToPeek))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
