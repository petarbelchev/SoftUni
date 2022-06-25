using System;

namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalDays = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double addPlunder = dailyPlunder * 0.5;
            double expectedPlunder = double.Parse(Console.ReadLine());
            double gatheredQuantity = 0;

            for (int day = 1; day <= totalDays; day++)
            {
                gatheredQuantity += dailyPlunder;

                if (day % 3 == 0)
                {
                    gatheredQuantity += addPlunder;
                }

                if (day % 5 == 0)
                {
                    gatheredQuantity -= gatheredQuantity * 0.3;
                }
            }

            if (gatheredQuantity >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {gatheredQuantity:f2} plunder gained.");
            }
            else
            {
                double percentage = (gatheredQuantity / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
