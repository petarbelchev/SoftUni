using System;

namespace _05._Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine())*100;
            double h = double.Parse(Console.ReadLine())*100;

            int placesByH = ((int)h - 100)/70;
            int placesByW = (int)w/120;

            int totalPlaces = (placesByH * placesByW) - 3;
            Console.WriteLine(totalPlaces);
        }
    }
}
