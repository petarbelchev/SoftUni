using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return OutputMessages.RaceCannotBeCompleted;

            racerOne.Race();
            racerTwo.Race();

            double racerOneMultiplier = racerOne.GetType().Name == nameof(ProfessionalRacer) ? 1.2 : 1.1;
            double racerTwoMultiplier = racerTwo.GetType().Name == nameof(ProfessionalRacer) ? 1.2 : 1.1;

            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;
            
            IRacer winner = racerOneChance > racerTwoChance ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}
