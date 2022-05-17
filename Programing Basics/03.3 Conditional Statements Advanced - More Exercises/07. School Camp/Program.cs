using System;

namespace _07._School_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeGroup = Console.ReadLine();
            int studentsQuantity = int.Parse(Console.ReadLine());
            int nightsQuantity = int.Parse(Console.ReadLine());

            double pricePerNight = 0;
            string sportsType = null;

            if (season == "Winter" && typeGroup == "mixed")
            {
                pricePerNight = 10;
                sportsType = "Ski";
            }
            else if (season == "Spring" && typeGroup == "mixed")
            {
                pricePerNight = 9.5;
                sportsType = "Cycling";
            }
            else if (season == "Summer" && typeGroup == "mixed")
            {
                pricePerNight = 20;
                sportsType = "Swimming";
            }
            else if (season == "Winter" && typeGroup == "boys")
            {
                pricePerNight = 9.6;
                sportsType = "Judo";
            }
            else if (season == "Winter" && typeGroup == "girls")
            {
                pricePerNight = 9.6;
                sportsType = "Gymnastics";
            }
            else if (season == "Spring" && typeGroup == "girls")
            {
                pricePerNight = 7.2;
                sportsType = "Athletics";
            }
            else if (season == "Spring" && typeGroup == "boys")
            {
                pricePerNight = 7.2;
                sportsType = "Tennis";
            }
            else if (season == "Summer" && typeGroup == "boys")
            {
                pricePerNight = 15;
                sportsType = "Football";
            }
            else if (season == "Summer" && typeGroup == "girls")
            {
                pricePerNight = 15;
                sportsType = "Volleyball";
            }

            double totalPrice = studentsQuantity * nightsQuantity * pricePerNight;

            if (studentsQuantity >= 50)
            {
                totalPrice -= totalPrice * 0.5;
            }
            else if (studentsQuantity >= 20 && studentsQuantity < 50)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (studentsQuantity >= 10 && studentsQuantity < 20)
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"{sportsType} {totalPrice:f2} lv.");
        }
    }
}
