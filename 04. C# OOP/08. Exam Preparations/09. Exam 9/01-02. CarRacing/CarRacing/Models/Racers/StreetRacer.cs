using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string InitialRacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }
    }
}
