using System;

namespace _05._Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodTotal = int.Parse(Console.ReadLine()) * 1000;
            int eatedFood = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Adopted")
                {
                    break;
                }

                eatedFood += int.Parse(input);
            }

            if (eatedFood <= foodTotal)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodTotal - eatedFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {eatedFood - foodTotal} grams more.");
            }
        }
    }
}
