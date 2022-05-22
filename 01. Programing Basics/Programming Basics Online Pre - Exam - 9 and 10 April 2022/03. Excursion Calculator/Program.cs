using System;

namespace _03._Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleQuantity = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double pricePerPerson = 0;

            if (peopleQuantity <= 5)
            {
                if (season == "spring")
                {
                    pricePerPerson = 50;
                }
                else if (season == "summer")
                {
                    pricePerPerson = 48.5;
                }
                else if (season == "autumn")
                {
                    pricePerPerson = 60;
                }
                else if (season == "winter")
                {
                    pricePerPerson = 86;
                }
            }
            else
            {
                if (season == "spring")
                {
                    pricePerPerson = 48;
                }
                else if (season == "summer")
                {
                    pricePerPerson = 45;
                }
                else if (season == "autumn")
                {
                    pricePerPerson = 49.5;
                }
                else if (season == "winter")
                {
                    pricePerPerson = 85;
                }
            }

            double totalPrice = peopleQuantity * pricePerPerson;

            if (season == "summer")
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (season == "winter")
            {
                totalPrice += totalPrice * 0.08;
            }

            Console.WriteLine($"{totalPrice:f2} leva.");
        }
    }
}
