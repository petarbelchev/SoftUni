using System;

namespace _7._Theatre_Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int ageOfPerson = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (ageOfPerson >= 0 && ageOfPerson <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;

                    case "Weekend":
                        ticketPrice = 15;
                        break;

                    case "Holiday":
                        ticketPrice = 5;
                        break;
                }
            }
            else if (ageOfPerson > 18 && ageOfPerson <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 18;
                        break;

                    case "Weekend":
                        ticketPrice = 20;
                        break;

                    case "Holiday":
                        ticketPrice = 12;
                        break;
                }
            }
            else if (ageOfPerson > 64 && ageOfPerson <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;

                    case "Weekend":
                        ticketPrice = 15;
                        break;

                    case "Holiday":
                        ticketPrice = 10;
                        break;
                }
            }
            
            if (ticketPrice > 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
