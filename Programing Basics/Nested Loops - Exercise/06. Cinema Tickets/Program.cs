using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentCount = 0;
            double standartCount = 0;
            double kidCount = 0;
            double currentStudentCount = 0;
            double currentStandartCount = 0;
            double currentKidCount = 0;
            double totalTickets = 0;
            double currentTickets = 0;

            while (true)
            {
                string movieName = Console.ReadLine();

                if (movieName == "Finish")
                {
                    Console.WriteLine($"Total tickets: {totalTickets}");
                    Console.WriteLine($"{(studentCount / totalTickets) * 100:f2}% student tickets.");
                    Console.WriteLine($"{(standartCount / totalTickets) * 100:f2}% standard tickets.");
                    Console.WriteLine($"{(kidCount / totalTickets) * 100:f2}% kids tickets.");
                    break;
                }

                int avSeats = int.Parse(Console.ReadLine());

                for (int i = 1; i <= avSeats; i++)
                {
                    string typeTicket = Console.ReadLine();

                    if (typeTicket == "End")
                    {
                        Console.WriteLine($"{movieName} - {(currentTickets / avSeats) * 100:f2}% full.");
                        currentTickets = 0;
                        currentStudentCount = 0;
                        currentStandartCount = 0;
                        currentKidCount = 0;
                        break;
                    }

                    switch (typeTicket)
                    {
                        case "student":
                            studentCount++;
                            currentStudentCount++;
                            break;
                        case "standard":
                            standartCount++;
                            currentStandartCount++;
                            break;
                        case "kid":
                            kidCount++;
                            currentKidCount++;
                            break;
                    }

                    totalTickets++;
                    currentTickets++;

                    if (currentTickets == avSeats)
                    {
                        Console.WriteLine($"{movieName} - {(currentTickets / avSeats) * 100:f2}% full.");
                        currentTickets = 0;
                        currentStudentCount = 0;
                        currentStandartCount = 0;
                        currentKidCount = 0;
                        break;
                    }
                }
            }
        }
    }
}
