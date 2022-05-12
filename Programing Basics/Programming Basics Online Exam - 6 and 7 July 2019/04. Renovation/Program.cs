using System;

namespace _04._Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heightWall = int.Parse(Console.ReadLine());
            int weightWall = int.Parse(Console.ReadLine());
            double percentWindowsDoors = int.Parse(Console.ReadLine());

            int areaWalls = (heightWall * weightWall) * 4;
            double areaForPaint = Math.Ceiling(areaWalls - (areaWalls * (percentWindowsDoors / 100)));

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tired!")
                {
                    Console.WriteLine($"{areaForPaint} quadratic m left.");
                    break;
                }

                int paintLiters = int.Parse(input);

                areaForPaint -= paintLiters;

                if (areaForPaint < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(areaForPaint)} l paint left!");
                    break;
                }
                else if (areaForPaint == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    break;
                }
            }
        }
    }
}
