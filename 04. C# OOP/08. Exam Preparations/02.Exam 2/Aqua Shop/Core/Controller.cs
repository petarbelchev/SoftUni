using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            Type type = Type.GetType($"AquaShop.Models.Decorations.{decorationType}");

            if (type == null)
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            var decInstance = (IDecoration)Activator.CreateInstance(type);

            this.decorations.Add(decInstance);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Type desiredFishType = Type.GetType($"AquaShop.Models.Fish.{fishType}");

            if (desiredFishType == null)
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var desiredAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            string waterType = fishType.Substring(0, fishType.Length - 4);

            if (!desiredAquarium.GetType().Name.StartsWith(waterType))
            {
                return "Water not suitable.";
            }

            try
            {
                var fishInstance = (IFish)Activator.CreateInstance(desiredFishType, fishName, fishSpecies, price);
                desiredAquarium.AddFish(fishInstance);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var fishPrice = aquarium.Fish.Select(a => a.Price).Sum();
            var decPrice = aquarium.Decorations.Select(d => d.Price).Sum();
            return $"The value of Aquarium {aquariumName} is {(fishPrice + decPrice):f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decToInsert = this.decorations.FindByType(decorationType);

            if (decToInsert == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.decorations.Remove(decToInsert);
            this.aquariums.FirstOrDefault(a => a.Name == aquariumName).AddDecoration(decToInsert);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
