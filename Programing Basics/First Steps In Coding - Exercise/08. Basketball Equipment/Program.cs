using System;

namespace _08._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int feePerYear = int.Parse(Console.ReadLine());

            double sneakersPrice = feePerYear - (feePerYear * 0.4);
            double outfitPrice = sneakersPrice - (sneakersPrice * 0.2);
            double ballPrice = outfitPrice / 4;
            double accessories = ballPrice / 5;
            double priceAllPerYear = feePerYear + sneakersPrice + outfitPrice + ballPrice + accessories;

            Console.WriteLine(priceAllPerYear);
        }
    }
}
