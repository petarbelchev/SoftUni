using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(double fuelQty, double fuelConsumption)
            :base(fuelQty, fuelConsumption)
        {
            this.FuelConsumption += airConditionerConsumption;
        }
    }
}
