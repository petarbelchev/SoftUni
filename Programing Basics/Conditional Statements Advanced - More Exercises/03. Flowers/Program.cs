using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemumsQuantity = int.Parse(Console.ReadLine());
            int rosesQuantity = int.Parse(Console.ReadLine());
            int tulipsQuantity = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holiday = char.Parse(Console.ReadLine());

            double chrysanthemumsPricePerUnit = 0;
            double rosesPricePerUnit = 0;
            double tulipsPricePerUnit = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumsPricePerUnit = 2;
                    rosesPricePerUnit = 4.1;
                    tulipsPricePerUnit = 2.5;
                    break;

                case "Autumn":
                case "Winter":
                    chrysanthemumsPricePerUnit = 3.75;
                    rosesPricePerUnit = 4.5;
                    tulipsPricePerUnit = 4.15;
                    break;
            }

            if (holiday == 'Y')
            {
                chrysanthemumsPricePerUnit += chrysanthemumsPricePerUnit * 0.15;
                rosesPricePerUnit += rosesPricePerUnit * 0.15;
                tulipsPricePerUnit += tulipsPricePerUnit * 0.15;
            }

            double bouquetPrice = chrysanthemumsPricePerUnit * chrysanthemumsQuantity + rosesPricePerUnit * rosesQuantity + tulipsPricePerUnit * tulipsQuantity;

            if (tulipsQuantity > 7 && season == "Spring")
            {
                bouquetPrice -= bouquetPrice * 0.05;
            }
            else if (rosesQuantity >= 10 && season == "Winter")
            {
                bouquetPrice -= bouquetPrice * 0.1;
            }

            if (chrysanthemumsQuantity + rosesQuantity + tulipsQuantity > 20)
            {
                bouquetPrice -= bouquetPrice * 0.2;
            }

            double totalPrice = bouquetPrice + 2;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
