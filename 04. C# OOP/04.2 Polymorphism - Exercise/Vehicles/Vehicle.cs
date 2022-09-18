using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQty, double fuelConsumption)
        {
            this.FuelQuantity = fuelQty;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; } //Liters per kilometer

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
