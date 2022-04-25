using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int allSeats = r * c;

            switch (type)
            {
                case "Premiere":
                    {
                        double income = allSeats * 12.00;
                        Console.WriteLine($"{income:f2} leva");
                        break;
                    }
                case "Normal":
                    {
                        double income = allSeats * 7.50;
                        Console.WriteLine($"{income:f2} leva");
                        break;
                    }
                case "Discount":
                    {
                        double income = allSeats * 5.00;
                        Console.WriteLine($"{income:f2} leva");
                        break;
                    }
            }

        }
    }
}
