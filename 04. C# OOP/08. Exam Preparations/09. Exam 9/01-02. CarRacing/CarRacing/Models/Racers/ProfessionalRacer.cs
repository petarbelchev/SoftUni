using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InitialRacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, InitialRacingBehavior, InitialDrivingExperience, car)
        {
        }
    }
}
