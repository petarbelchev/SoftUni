using System;

namespace _04._Car_To_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string typeCar = null;
            string classType = null;
            double carPrice = 0;

            switch (season)
            {
                case "Summer":

                    if (budget <= 100)
                    {
                        typeCar = "Cabrio";
                        classType = "Economy class";
                        carPrice = budget * 0.35;
                    }
                    else if (budget > 100 && budget <= 500)
                    {
                        typeCar = "Cabrio";
                        classType = "Compact class";
                        carPrice = budget * 0.45;
                    }
                    else if (budget > 500)
                    {
                        typeCar = "Jeep";
                        classType = "Luxury class";
                        carPrice = budget * 0.9;
                    }

                    break;


                case "Winter":

                    if (budget <= 100)
                    {
                        typeCar = "Jeep";
                        classType = "Economy class";
                        carPrice = budget * 0.65;
                    }
                    else if (budget > 100 && budget <= 500)
                    {
                        typeCar = "Jeep";
                        classType = "Compact class";
                        carPrice = budget * 0.8;
                    }
                    else if (budget > 500)
                    {
                        typeCar = "Jeep";
                        classType = "Luxury class";
                        carPrice = budget * 0.9;
                    }

                    break;
            }

            Console.WriteLine(classType);
            Console.WriteLine($"{typeCar} - {carPrice:f2}");
        }
    }
}
