using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;
        private const double percentOfRealRefueledFuel = 0.95;

        public Truck(double fuelQty, double fuelConsumption)
            : base(fuelQty, fuelConsumption)
        {
            this.FuelConsumption += airConditionerConsumption;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * percentOfRealRefueledFuel;
        }
    }
}
