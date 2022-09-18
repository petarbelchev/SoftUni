using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<string> TypeOfFoodForEat { get; }

        public abstract void ProduceSound();
        public void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            if (!this.TypeOfFoodForEat.Contains(foodType))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
                return;
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
    }
}
