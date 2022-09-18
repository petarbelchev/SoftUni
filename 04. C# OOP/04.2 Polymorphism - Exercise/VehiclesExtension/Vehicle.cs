using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(int fuelQty, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQty > tankCapacity? 0 : fuelQty;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public int TankCapacity { get; protected set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
                Console.WriteLine($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else if (this.TankCapacity - this.FuelQuantity < liters)
                Console.WriteLine($"Cannot fit {liters} fuel in the tank" );
            else
                this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
