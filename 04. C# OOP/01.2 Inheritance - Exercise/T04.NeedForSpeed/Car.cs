﻿namespace T04.NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = 3;
        }
    }
}
