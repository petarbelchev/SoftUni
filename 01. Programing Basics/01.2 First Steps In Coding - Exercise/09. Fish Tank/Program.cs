using System;

namespace _09._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int widgh = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentValue = double.Parse(Console.ReadLine());

            double percent = percentValue / 100.0;
            double capacityTankLitres = (lenght * widgh * height) / 1000.0;
            double capacityTankForWater = capacityTankLitres - (capacityTankLitres * percent);

            Console.WriteLine(capacityTankForWater);
        }
    }
}
