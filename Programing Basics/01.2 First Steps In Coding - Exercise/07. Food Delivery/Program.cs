using System;

namespace _07._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenuCount = int.Parse(Console.ReadLine());
            int fishMenuCount = int.Parse(Console.ReadLine());
            int veganMenuCount = int.Parse(Console.ReadLine());

            double chickenMenuPrice = chickenMenuCount * 10.35;
            double fishMenuPrice = fishMenuCount * 12.4;
            double veganMenuPrice = veganMenuCount * 8.15;
            double desertPrice = (chickenMenuPrice + fishMenuPrice + veganMenuPrice) * 0.2;
            double deliveryPrice = 2.5;

            double priceAll = chickenMenuPrice + fishMenuPrice + veganMenuPrice + desertPrice + deliveryPrice;

            Console.WriteLine(priceAll);
        }
    }
}
