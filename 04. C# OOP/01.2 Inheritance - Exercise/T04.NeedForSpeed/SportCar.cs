﻿namespace T04.NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = 10;
        }
    }
}
