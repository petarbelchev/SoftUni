using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> Participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count { get => this.Participants.Count; }

        public void Add(Car car)
        {
            if (this.Participants.Any(c => c.LicensePlate == car.LicensePlate) == false &&
                this.Capacity > this.Participants.Count &&
                car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var carForRemove = this.Participants
                .FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (carForRemove != null)
            {
                this.Participants.Remove(carForRemove);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return this.Participants
                .OrderByDescending(c => c.HorsePower)
                .FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
