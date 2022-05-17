using System;

namespace _02._Bike_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trackType = Console.ReadLine();
            double feePriceJuniors = 0;
            double feePriceSeniors = 0;

            switch (trackType)
            {
                case "trail":
                    feePriceJuniors = 5.5;
                    feePriceSeniors = 7;
                    break;


                case "cross-country":
                    feePriceJuniors = 8;
                    feePriceSeniors = 9.5;
                    if (juniors+seniors >=50)
                    {
                        feePriceJuniors -= feePriceJuniors * 0.25;
                        feePriceSeniors -= feePriceSeniors * 0.25;
                    }
                    break;


                case "downhill":
                    feePriceJuniors = 12.25;
                    feePriceSeniors = 13.75;
                    break;


                case "road":
                    feePriceJuniors = 20;
                    feePriceSeniors = 21.5;
                    break;
            }

            double collectedAmount = (juniors * feePriceJuniors) + (seniors * feePriceSeniors);
            double donatedAmount = collectedAmount - (collectedAmount * 0.05);

            Console.WriteLine($"{donatedAmount:f2}");
        }
    }
}
