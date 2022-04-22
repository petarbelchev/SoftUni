using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacantionPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int bearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            int ordersCount = puzzleCount + dollsCount + bearsCount + minionsCount + trucksCount;
            double orderPrice = puzzleCount * 2.60 + dollsCount * 3 + bearsCount * 4.10 
                + minionsCount * 8.20 + trucksCount * 2;

            if (ordersCount >= 50)
            {
                orderPrice = orderPrice - orderPrice * 0.25;
            }

            orderPrice = orderPrice - orderPrice * 0.1;

            if (orderPrice >= vacantionPrice)
            {
                Console.WriteLine($"Yes! {orderPrice - vacantionPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacantionPrice - orderPrice:f2} lv needed.");
            }
        }
    }
}
