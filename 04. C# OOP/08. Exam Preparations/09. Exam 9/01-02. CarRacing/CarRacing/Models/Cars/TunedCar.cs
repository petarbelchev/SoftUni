namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuel = 65;
        private const double InitialConsumption = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, InitialFuel, InitialConsumption)
        {
        }
    }
}
