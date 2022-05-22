using System;

namespace _10._Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity1 = int.Parse(Console.ReadLine());
            int quantity2 = int.Parse(Console.ReadLine());
            int quantity5 = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int firstCount = 0; firstCount <= quantity1; firstCount++)
            {
                for (int secondCount = 0; secondCount <= quantity2; secondCount++)
                {
                    for (int thirdCount = 0; thirdCount <= quantity5; thirdCount++)
                    {
                        if ((firstCount * 1) + (secondCount * 2) + (thirdCount * 5) == sum)
                        {
                            Console.WriteLine($"{firstCount} * 1 lv. + {secondCount} * 2 lv. + {thirdCount} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
