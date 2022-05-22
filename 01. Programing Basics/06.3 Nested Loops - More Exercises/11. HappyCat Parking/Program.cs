using System;

namespace _11._HappyCat_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double totalAllDays = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                double totalCurrentDay = 0;

                for (int currentHour = 1; currentHour <= hours; currentHour++)
                {
                    double currentPrice = 0;

                    if (currentDay % 2 == 0 && currentHour % 2 != 0)
                    {
                        currentPrice = 2.5;
                    }
                    else if (currentDay % 2 != 0 && currentHour % 2 == 0)
                    {
                        currentPrice = 1.25;
                    }
                    else
                    {
                        currentPrice = 1;
                    }

                    totalCurrentDay += currentPrice;
                }

                Console.WriteLine($"Day: {currentDay} - {totalCurrentDay:f2} leva");

                totalAllDays += totalCurrentDay;
            }

            Console.WriteLine($"Total: {totalAllDays:f2} leva");
        }
    }
}
