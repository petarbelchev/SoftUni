using System;
using System.Collections.Generic;

namespace _07._ParkLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var parkingLot = new HashSet<string>();

            while (input != "END")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = data[0];
                string carNumber = data[1];

                if (direction == "IN")
                    parkingLot.Add(carNumber);

                else if (direction == "OUT")
                    parkingLot.Remove(carNumber);

                input = Console.ReadLine();
            }

            if (parkingLot.Count > 0)
                Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
