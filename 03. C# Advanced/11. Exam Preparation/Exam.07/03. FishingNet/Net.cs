using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {

        public Net(string material, int capacity)
        {
            this.Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish { get; private set; }
        public string Material { get; private set; }
        public int Capacity { get; private set; }

        public int Count { get => this.Fish.Count; }

        public string AddFish(Fish fish)
        {
            if (this.Capacity == this.Fish.Count)
                return "Fishing net is full.";

            if (string.IsNullOrEmpty(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
                return "Invalid fish.";

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(f => f.Weight == weight);

            if (fish == null)
            {
                return false;
            }

            this.Fish.Remove(fish);
            return true;
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(f => f.Length).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
