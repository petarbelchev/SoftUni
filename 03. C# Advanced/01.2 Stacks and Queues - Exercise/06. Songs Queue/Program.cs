using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string[] cmd = Console.ReadLine().Split(' ');

                Queue<string> cmdQueue = new Queue<string>(cmd);                

                switch (cmdQueue.Dequeue())
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;

                    case "Add":
                        string newSong = string.Join(' ',cmdQueue);

                        if (!songsQueue.Contains(newSong))
                        {
                            songsQueue.Enqueue(newSong);
                        }
                        else
                        {
                            Console.WriteLine($"{newSong} is already contained!");
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
