using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        public Zoo(string name, int capacity)
        {
            this.Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return $"Invalid animal diet.";
            }

            if (this.Capacity == this.Animals.Count)
            {
                return $"The zoo is full.";
            }

            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int initCount = this.Animals.Count;
            this.Animals.RemoveAll(animals => animals.Species == species);

            return initCount - this.Animals.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return this.Animals.Where(a => a.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = this.Animals.Where(a => a.Length >= minimumLength && a.Length <= maximumLength).Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
