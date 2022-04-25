using System;

namespace _07._Hotel_Room_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nigthsQuantity = int.Parse(Console.ReadLine());

            double totalPriceAp = 0;
            double totalPriceSt = 0;

            switch (month)
            {
                case "May":
                case "October":
                    totalPriceSt = (nigthsQuantity * 50);
                    totalPriceAp = (nigthsQuantity * 65);

                    if (nigthsQuantity > 7 && nigthsQuantity <= 14)
                    {
                        totalPriceSt -= ((nigthsQuantity * 50) * 0.05);
                    }
                    else if (nigthsQuantity >= 15)
                    {
                        totalPriceSt -= ((nigthsQuantity * 50) * 0.3);
                        totalPriceAp -= ((nigthsQuantity * 65) * 0.1);
                    }
                    break;


                case "June":
                case "September":
                    totalPriceSt = (nigthsQuantity * 75.2);
                    totalPriceAp = (nigthsQuantity * 68.7);

                    if (nigthsQuantity >= 15)
                    {
                        totalPriceSt -= ((nigthsQuantity * 75.2) * 0.2);
                        totalPriceAp -= ((nigthsQuantity * 68.7) * 0.1);
                    }
                    break;


                case "July":
                case "August":
                    totalPriceSt = (nigthsQuantity * 76);
                    totalPriceAp = (nigthsQuantity * 77);
                    if (nigthsQuantity >= 15)
                    {
                        totalPriceAp -= ((nigthsQuantity * 77) * 0.1);
                    }
                    break;
            }

            Console.WriteLine($"Apartment: {totalPriceAp:f2} lv.");
            Console.WriteLine($"Studio: {totalPriceSt:f2} lv.");
        }
    }
}
