using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carDetails = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carDetails[0];
                double fuelAmount = int.Parse(carDetails[1]);
                double fuelConsumptionFor1km = double.Parse(carDetails[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(newCar);
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = cmdArgs[1];
                int amountOfKm = int.Parse(cmdArgs[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        if (car.IsFuelEnough(amountOfKm))
                        {
                            car.Drive(amountOfKm);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TraveledDistance { get; set; }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDistance}";
        }

        public bool IsFuelEnough(int amountOfKm)
        {
            if (amountOfKm * FuelConsumptionPerKilometer <= FuelAmount)
            {
                return true;
            }

            return false;
        }

        public void Drive(int amountOfKg)
        {
            FuelAmount -= amountOfKg * FuelConsumptionPerKilometer;
            TraveledDistance += amountOfKg;
        }
    }
}
