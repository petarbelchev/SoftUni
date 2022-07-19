using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCarsCanPass = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    int initialCount = queue.Count;

                    for (int i = 1; i <= initialCount && i <= numOfCarsCanPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
