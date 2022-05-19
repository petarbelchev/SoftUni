using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            decimal ticketPrice = 0.00m;

            if (dayOfWeek == "Friday")
            {
                if (typeOfGroup == "Students")
                {
                    ticketPrice = 8.45m;
                }
                else if (typeOfGroup == "Business")
                {
                    ticketPrice = 10.9m;
                }
                else if (typeOfGroup == "Regular")
                {
                    ticketPrice = 15;
                }
            }
            else if (dayOfWeek == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    ticketPrice = 9.8m;
                }
                else if (typeOfGroup == "Business")
                {
                    ticketPrice = 15.6m;
                }
                else if (typeOfGroup == "Regular")
                {
                    ticketPrice = 20;
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    ticketPrice = 10.46m;
                }
                else if (typeOfGroup == "Business")
                {
                    ticketPrice = 16;
                }
                else if (typeOfGroup == "Regular")
                {
                    ticketPrice = 22.5m;
                }
            }

            decimal totalPrice = countOfPeople * ticketPrice;

            if (countOfPeople >= 30 && typeOfGroup == "Students")
            {
                totalPrice -= totalPrice * 0.15m;
            }
            else if (countOfPeople >= 100 && typeOfGroup == "Business")
            {
                totalPrice = (countOfPeople - 10) * ticketPrice;
            }
            else if ((countOfPeople >= 10 && countOfPeople <= 20) && typeOfGroup == "Regular")
            {
                totalPrice -= totalPrice * 0.05m;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
