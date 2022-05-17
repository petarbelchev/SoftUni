using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDogFood = int.Parse(Console.ReadLine());
            int numberCatFood = int.Parse(Console.ReadLine());
            double priceDogFood = numberDogFood * 2.50;
            int priceCatFood = numberCatFood * 4;
            double priceAll = priceDogFood + priceCatFood;
            Console.WriteLine(priceAll + " lv.");

        }
    }
}
