using System;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal food = decimal.Parse(Console.ReadLine());
            decimal hay = decimal.Parse(Console.ReadLine());
            decimal cover = decimal.Parse(Console.ReadLine());
            decimal weight = decimal.Parse(Console.ReadLine());

            bool isMustGoToTheStore = false;

            for (int day = 1; day <= 30; day++)
            {
                food -= 0.300m;

                if (food <= 0)
                {
                    isMustGoToTheStore = true;
                    break;
                }

                if (day % 2 == 0)
                {
                    hay -= food * 0.05m;
                }

                if (hay <= 0)
                {
                    isMustGoToTheStore = true;
                    break;
                }

                if (day % 3 == 0)
                {
                    cover -= weight / 3;
                }

                if (cover <= 0)
                {
                    isMustGoToTheStore = true;
                    break;
                }
            }

            if (isMustGoToTheStore)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
