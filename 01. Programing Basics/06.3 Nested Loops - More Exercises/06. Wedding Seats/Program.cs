using System;

namespace _06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsSectorA = int.Parse(Console.ReadLine());
            int seatsOddRow = int.Parse(Console.ReadLine());
            int seatsEvenRow = seatsOddRow + 2;
            int currentRowSeats = 96;
            int seatsCounter = 0;

            for (char currentSector = 'A'; currentSector <= lastSector; currentSector++)
            {
                for (int currentSectorRow = 1; currentSectorRow <= rowsSectorA; currentSectorRow++)
                {
                    if (currentSectorRow % 2 != 0)
                    {
                        currentRowSeats += seatsOddRow;
                    }
                    else
                    {
                        currentRowSeats += seatsEvenRow;
                    }

                    for (char currentRowSeat = 'a'; currentRowSeat <= currentRowSeats; currentRowSeat++)
                    {
                        Console.WriteLine($"{currentSector}{currentSectorRow}{currentRowSeat}");
                        seatsCounter++;
                    }

                    currentRowSeats = 96;
                }

                rowsSectorA++;
            }

            Console.WriteLine(seatsCounter);
        }
    }
}
