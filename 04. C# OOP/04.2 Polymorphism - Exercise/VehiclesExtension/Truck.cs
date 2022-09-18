using System;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;
        private const double percentOfRealRefueledFuel = 0.95;

        public Truck(int fuelQty, double fuelConsumption, int tankCapacity)
            : base(fuelQty, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionerConsumption;
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (this.TankCapacity - this.FuelQuantity < liters * percentOfRealRefueledFuel)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else
                this.FuelQuantity += liters * percentOfRealRefueledFuel;
        }
    }
}
