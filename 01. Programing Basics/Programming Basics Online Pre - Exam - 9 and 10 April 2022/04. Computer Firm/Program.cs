using System;

namespace _04._Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int computersQuantity = int.Parse(Console.ReadLine());
            double ratingSum = 0;
            double sales = 0;

            for (int numComputer = 1; numComputer <= computersQuantity; numComputer++)
            {
                int salesAndRating = int.Parse(Console.ReadLine());

                int currentRating = salesAndRating % 10;
                ratingSum += salesAndRating % 10;
                double possibleSales = salesAndRating / 10;

                if (currentRating == 2)
                {
                    sales += 0;
                }
                else if (currentRating == 3)
                {
                    sales += possibleSales * 0.5;
                }
                else if (currentRating == 4)
                {
                    sales += possibleSales * 0.7;
                }
                else if (currentRating == 5)
                {
                    sales += possibleSales * 0.85;
                }
                else if (currentRating == 6)
                {
                    sales += possibleSales;
                }
            }

            Console.WriteLine($"{sales:f2}");
            Console.WriteLine($"{ratingSum / computersQuantity:f2}");
        }
    }
}
