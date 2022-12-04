using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == nameof(BoxingGym))
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment.Add(new BoxingGloves());
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            string gymType = gym.GetType().Name;

            if ((athleteType.StartsWith("Box") && gymType.StartsWith("Box")) 
                || (athleteType.StartsWith("Weight") && gymType.StartsWith("Weight")))
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
        }
        
        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (var a in gym.Athletes)
            {
                a.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            double equipmentWeight = Math.Round(gym.EquipmentWeight, 2);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, equipmentWeight);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var g in gyms)
            {
                sb.AppendLine(g.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
