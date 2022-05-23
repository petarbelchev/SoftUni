using System;

namespace _01._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal distanceInMeters = int.Parse(Console.ReadLine());
            decimal distanceInKilometers = distanceInMeters / 1000;
            Console.WriteLine($"{distanceInKilometers:f2}");
        }
    }
}
