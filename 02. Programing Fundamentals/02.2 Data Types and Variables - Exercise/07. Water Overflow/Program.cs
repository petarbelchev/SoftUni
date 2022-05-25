using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pourCount = int.Parse(Console.ReadLine());
            int waterTankCapacity = 255;

            for (int i = 1; i <= pourCount; i++)
            {
                int currPour = int.Parse(Console.ReadLine());

                if (waterTankCapacity >= currPour)
                {
                    waterTankCapacity -= currPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(255 - waterTankCapacity);
        }
    }
}
