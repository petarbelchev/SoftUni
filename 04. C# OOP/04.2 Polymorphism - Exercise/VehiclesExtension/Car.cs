using System;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(int fuelQty, double fuelConsumption, int tankCapacity)
            :base(fuelQty, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionerConsumption;
        }
    }
}
