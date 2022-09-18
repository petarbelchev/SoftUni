using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double airConditionerConsumption = 1.4;

        public Bus(int fuelQty, double fuelConsumption, int tankCapacity)
            : base(fuelQty, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionerConsumption;
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= airConditionerConsumption;

            this.Drive(distance);
        }
    }
}
