using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ');

            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(kids);

            int counter = 0;

            while (queue.Count > 1)
            {
                counter++;
                
                string currKid = queue.Dequeue();

                if (counter == n)
                {
                    Console.WriteLine($"Removed {currKid}");
                    counter = 0;
                }
                else
                {
                    queue.Enqueue(currKid);
                }
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
