using System;

namespace _03._Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameMovie = Console.ReadLine();
            string type = Console.ReadLine();
            int ticketsQuantity = int.Parse(Console.ReadLine());
            double ticketsPrice = 0;

            switch (type)
            {
                case "normal":

                    switch (nameMovie)
                    {
                        case "A Star Is Born":
                            ticketsPrice = 7.5;
                            break;

                        case "Bohemian Rhapsody":
                            ticketsPrice = 7.35;
                            break;

                        case "Green Book":
                            ticketsPrice = 8.15;
                            break;

                        case "The Favourite":
                            ticketsPrice = 8.75;
                            break;
                    }

                    break;

                case "luxury":

                    switch (nameMovie)
                    {
                        case "A Star Is Born":
                            ticketsPrice = 10.5;
                            break;

                        case "Bohemian Rhapsody":
                            ticketsPrice = 9.45;
                            break;

                        case "Green Book":
                            ticketsPrice = 10.25;
                            break;

                        case "The Favourite":
                            ticketsPrice = 11.55;
                            break;
                    }

                    break;

                case "ultra luxury":

                    switch (nameMovie)
                    {
                        case "A Star Is Born":
                            ticketsPrice = 13.5;
                            break;

                        case "Bohemian Rhapsody":
                            ticketsPrice = 12.75;
                            break;

                        case "Green Book":
                            ticketsPrice = 13.25;
                            break;

                        case "The Favourite":
                            ticketsPrice = 13.95;
                            break;
                    }

                    break;
            }

            Console.WriteLine($"{nameMovie} -> {ticketsQuantity * ticketsPrice:f2} lv.");
        }
    }
}
