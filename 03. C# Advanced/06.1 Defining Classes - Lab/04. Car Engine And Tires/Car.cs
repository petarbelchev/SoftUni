using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumpsion;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumpsion) 
            : this(make, model, year)
        {
            FuelConsumption = fuelConsumpsion;
            FuelQuantity = fuelQuantity;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumpsion, Engine engine, Tire[] tires)
            :this(make, model, year, fuelQuantity, fuelConsumpsion)
        {
            Engine = engine;
            Tires = tires;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumpsion; }
            set { fuelConsumpsion = value; }
        }

        public Engine Engine 
        {
            get { return engine; }
            set { engine = value; }
        }

        public Tire[] Tires 
        {
            get { return tires; }
            set { tires = value; } 
        }

        public void Drive(double distance)
        {
            if (fuelQuantity - (distance * fuelConsumpsion / 100) >= 0)
            {
                fuelQuantity -= distance * fuelConsumpsion / 100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {make}\nModel: {model}\nYear: {year}\nFuel: {fuelQuantity}";
        }
    }
}
