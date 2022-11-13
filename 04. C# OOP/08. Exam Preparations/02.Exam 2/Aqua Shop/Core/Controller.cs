using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
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
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            else if (aquariumType == "SaltwaterAquarium")
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            else if (aquariumType == "FreshwaterAquarium")
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));


            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            Type type = Type.GetType($"AquaShop.Models.Decorations.{decorationType}");

            if (type == null)
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            var decInstance = (IDecoration)Activator.CreateInstance(type);

            this.decorations.Add(decInstance);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var currAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IFish currFish;

            if (fishType == "FreshwaterFish")
                currFish = new FreshwaterFish(fishName, fishSpecies, price);
            else if (fishType == "SaltwaterFish")
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            string aquariumWaterType = currAquarium.GetType().Name.Replace("Aquarium", string.Empty);
            string fishWaterType = currFish.GetType().Name.Replace("Fish", string.Empty);

            if (aquariumWaterType != fishWaterType)
                return OutputMessages.UnsuitableWater;

            currAquarium.AddFish(currFish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var fishPrice = aquarium.Fish.Sum(a => a.Price);
            var decPrice = aquarium.Decorations.Sum(d => d.Price);
            var sumPrice = fishPrice + decPrice;

            return string.Format(OutputMessages.AquariumValue, aquariumName, sumPrice);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decToInsert = this.decorations.FindByType(decorationType);

            if (decToInsert == null)
                throw new InvalidOperationException(string
                    .Format(ExceptionMessages.InexistentDecoration, decorationType));

            this.decorations.Remove(decToInsert);
            this.aquariums.FirstOrDefault(a => a.Name == aquariumName).AddDecoration(decToInsert);


            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
                sb.AppendLine(aquarium.GetInfo());

            return sb.ToString().TrimEnd();
        }
    }
}
