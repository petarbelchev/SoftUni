using System;
using System.Collections.Generic;

namespace NeedForSpeed
{
    class Program
    {
        static void Main()
        {
            var cars = new Dictionary<string, Car>();

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                cars[carData[0]] = new Car(int.Parse(carData[1]), int.Parse(carData[2]));
            }

            string cmd;

            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = cmd.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string car = cmdArgs[1];

                if (cmdArgs[0] == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (cars[car].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        continue;
                    }

                    cars[car].Fuel -= fuel;
                    cars[car].Mileage += distance;
                    Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                    if (cars[car].Mileage >= 100_000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (cmdArgs[0] == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2]);
                    int fuelBefore = cars[car].Fuel;
                    cars[car].Fuel += fuel;

                    if (cars[car].Fuel > 75)
                    {
                        cars[car].Fuel = 75;
                    }

                    Console.WriteLine($"{car} refueled with {cars[car].Fuel - fuelBefore} liters");
                }
                else if (cmdArgs[0] == "Revert")
                {
                    int kilometers = int.Parse(cmdArgs[2]);
                    cars[car].Mileage -= kilometers;
                    if (cars[car].Mileage >= 10_000)
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                    else
                    {
                        cars[car].Mileage = 10_000;
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public Car(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
