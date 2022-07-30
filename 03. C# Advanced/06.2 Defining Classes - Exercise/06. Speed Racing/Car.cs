namespace _06._Speed_Racing
{
    using System;
    public class Car
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
        public double TravelledDistance { get; set; }

        public void Drive(double amountOfKilometers)
        {
            if (FuelAmount - (amountOfKilometers * FuelConsumptionPerKilometer) >= 0)
            {
                FuelAmount -= amountOfKilometers * FuelConsumptionPerKilometer;
                TravelledDistance += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
