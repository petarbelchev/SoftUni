using System;

namespace _01._Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSerial = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double timeEpisode = double.Parse(Console.ReadLine());

            double ads = timeEpisode * 0.2;
            double lastEpisode = seasons * 10;

            double totalTime = (seasons * episodes) * (timeEpisode + ads) + lastEpisode;

            Console.WriteLine($"Total time needed to watch the {nameSerial} series is {Math.Floor(totalTime)} minutes.");
        }
    }
}
