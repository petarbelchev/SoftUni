namespace CarManufacturer
{
    using System;

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumpsion;

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
