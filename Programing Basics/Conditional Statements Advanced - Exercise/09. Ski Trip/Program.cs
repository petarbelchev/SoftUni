using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {


            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string rating = Console.ReadLine();



            int nights = days - 1;
            double totalPrice = 0;



            if (days < 10)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18;
                        break;

                    case "apartment":
                        totalPrice = nights * 25;
                        totalPrice -= totalPrice * 0.3;
                        break;

                    case "president apartment":
                        totalPrice = nights * 35;
                        totalPrice -= totalPrice * 0.1;
                        break;
                }
                switch (rating)
                {
                    case "positive":
                        totalPrice += totalPrice * 0.25;
                        break;
                    case "negative":
                        totalPrice -= totalPrice * 0.1;
                        break;
                }
            }



            else if (days >= 10 && days < 15 || days == 15)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18;
                        break;

                    case "apartment":
                        totalPrice = nights * 25;
                        totalPrice -= totalPrice * 0.35;
                        break;

                    case "president apartment":
                        totalPrice = nights * 35;
                        totalPrice -= totalPrice * 0.15;
                        break;
                }
                switch (rating)
                {
                    case "positive":
                        totalPrice += totalPrice * 0.25;
                        break;
                    case "negative":
                        totalPrice -= totalPrice * 0.1;
                        break;
                }
            }



            else if (15 < days)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18;
                        break;

                    case "apartment":
                        totalPrice = nights * 25;
                        totalPrice -= totalPrice * 0.5;
                        break;

                    case "president apartment":
                        totalPrice = nights * 35;
                        totalPrice -= totalPrice * 0.2;
                        break;
                }
                switch (rating)
                {
                    case "positive":
                        totalPrice += totalPrice * 0.25;
                        break;
                    case "negative":
                        totalPrice -= totalPrice * 0.1;
                        break;
                }
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
