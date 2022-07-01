using System;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalogOfVehicles = new List<Catalog>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] vehicleDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleDetails[0];
                string model = vehicleDetails[1];
                string color = vehicleDetails[2];
                double horsePower = double.Parse(vehicleDetails[3]);

                catalogOfVehicles.Add(new Catalog(type, model, color, horsePower));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                string modelOfVehicle = input;

                foreach (Catalog vehicle in catalogOfVehicles)
                {
                    if (vehicle.Model == modelOfVehicle)
                    {
                        Console.WriteLine($"Type: {vehicle.Type}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                    }
                }

                input = Console.ReadLine();
            }

            double sumHorsePowerCars = 0;
            int counterCars = 0;
            double sumHorsePowerTrucks = 0;
            int counterTrucks = 0;

            foreach (Catalog vehicle in catalogOfVehicles)
            {
                if (vehicle.Type == "Car")
                {
                    sumHorsePowerCars += vehicle.HorsePower;
                    counterCars++;
                }
                else if (vehicle.Type == "Truck")
                {
                    sumHorsePowerTrucks += vehicle.HorsePower;
                    counterTrucks++;
                }
            }

            double avHorsePowerCars = 0;
            if (counterCars > 0)
            {
                avHorsePowerCars = sumHorsePowerCars / counterCars;
            }

            double avHorsePowerTrucks = 0;
            if (counterTrucks > 0)
            {
                avHorsePowerTrucks = sumHorsePowerTrucks / counterTrucks;
            }

            Console.WriteLine($"Cars have average horsepower of: {avHorsePowerCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avHorsePowerTrucks:f2}.");
        }
    }

    class Catalog
    {
        public Catalog(string type, string model, string color, double horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;

            if (this.Type == "car")
            {
                this.Type = "Car";
            }
            else if (this.Type == "truck")
            {
                this.Type = "Truck";
            }
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
}
