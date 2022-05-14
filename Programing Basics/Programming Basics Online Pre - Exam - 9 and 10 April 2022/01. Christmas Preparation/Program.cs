using System;

namespace _01._Christmas_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int paperRollersQuantity = int.Parse(Console.ReadLine());
            int fabricRollersQuantity = int.Parse(Console.ReadLine());
            double glueLitersQuantity = double.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());

            double paperRollersPrice = paperRollersQuantity * 5.8;
            double fabricRollersPrice = fabricRollersQuantity * 7.2;
            double gluePrice = glueLitersQuantity * 1.2;

            double totalPrice = paperRollersPrice + fabricRollersPrice + gluePrice;
            double totalPriceDiscounted = totalPrice - ((totalPrice * percentDiscount) / 100);

            Console.WriteLine($"{totalPriceDiscounted:f3}");
        }
    }
}
