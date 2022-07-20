using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int qtyOfFood = int.Parse(Console.ReadLine()); // [0 - 1000]

            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                if (qtyOfFood >= queue.Peek())
                {
                    qtyOfFood -= queue.Dequeue();
                }
                else
                {
                    Console.Write($"Orders left: ");
                    Console.WriteLine(string.Join(' ', queue));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
