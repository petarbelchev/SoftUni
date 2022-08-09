using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public List<Drone> Drones { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; private set; }
        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || 
                string.IsNullOrEmpty(drone.Brand) || 
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (Capacity <= Drones.Count)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone droneToRemove = Drones.FirstOrDefault(drone => drone.Name == name);

            if (droneToRemove == null)
                return false;
            else
            {
                Drones.Remove(droneToRemove);
                return true;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removedDronesCount = Drones.RemoveAll(drone => drone.Brand == brand);

            return removedDronesCount;
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = Drones.FirstOrDefault(drone => drone.Name == name);
            if (droneToFly != null)
            {
                droneToFly.Available = false;
            }
            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = Drones.FindAll(drone => drone.Range >= range);
            for (int i = 0; i < dronesToFly.Count; i++)
                dronesToFly[i].Available = false;
            return dronesToFly;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(drone => drone.Available == true))
            {
                sb.AppendLine($"{drone}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
