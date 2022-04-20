using System;

namespace _05._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pensCount = int.Parse(Console.ReadLine());
            int markersCount = int.Parse(Console.ReadLine());
            int preparationLiters = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pensPrice = pensCount * 5.8;
            double markersPrice = markersCount * 7.2;
            double preparationPrice = preparationLiters * 1.2;

            double percentDiscount = discount / 100.0;

            double priceAll = pensPrice + markersPrice + preparationPrice;

            double priceAllWithDiscount = priceAll - (priceAll * percentDiscount);

            Console.WriteLine(priceAllWithDiscount);
        }
    }
}
