using System;

namespace _04._Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysTotal = int.Parse(Console.ReadLine());
            double foodTotal = double.Parse(Console.ReadLine());
            double foodDogTotal = 0;
            double foodCatTotal = 0;
            double biscuitsTotal = 0;

            for (int dayCurrent = 1; dayCurrent <= daysTotal; dayCurrent++)
            {
                int foodDogCurrent = int.Parse(Console.ReadLine());
                int foodCatCurrent = int.Parse(Console.ReadLine());

                if (dayCurrent % 3 == 0)
                {
                    double biscuitsCurrent = (foodCatCurrent + foodDogCurrent) * 0.1;
                    biscuitsTotal += biscuitsCurrent;
                }

                foodCatTotal += foodCatCurrent;
                foodDogTotal += foodDogCurrent;
            }

            double percentEatedTotal = ((foodDogTotal + foodCatTotal) / foodTotal) * 100;
            double percentEatedDog = (foodDogTotal / (foodDogTotal + foodCatTotal)) * 100;
            double percentEatedCat = (foodCatTotal / (foodDogTotal + foodCatTotal)) * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsTotal)}gr.");
            Console.WriteLine($"{percentEatedTotal:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentEatedDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentEatedCat:f2}% eaten from the cat.");
        }
    }
}
