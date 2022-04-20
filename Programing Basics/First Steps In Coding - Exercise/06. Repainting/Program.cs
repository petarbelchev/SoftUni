using System;

namespace _06._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylonCount = int.Parse(Console.ReadLine());
            int paintLitres = int.Parse(Console.ReadLine());
            int thinnerLitres = int.Parse(Console.ReadLine());
            int workHours = int.Parse(Console.ReadLine());

            double nylonPrice = (nylonCount + 2) * 1.5;
            double paintPrice = (paintLitres + (paintLitres * 0.1)) * 14.5;
            double thinnerPrice = thinnerLitres * 5;
            double bagsPrice = 0.4;
            double materialsPrice = nylonPrice + paintPrice + thinnerPrice + bagsPrice;
            double workPricePerHour = materialsPrice * 0.3;

            double priceAll = materialsPrice + (workPricePerHour * workHours);

            Console.WriteLine(priceAll);

        }
    }
}
