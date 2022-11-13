namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using Contracts;
    using Decorations.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
            => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
                fish.Eat();
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine(this.Fish.Count > 0 ?
                $"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}"
                : "Fish: none");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
            => this.Fish.Remove(fish);
    }
}
