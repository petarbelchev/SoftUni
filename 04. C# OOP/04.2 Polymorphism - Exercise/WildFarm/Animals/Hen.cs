namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => 0.35;

        public override IReadOnlyCollection<string> TypeOfFoodForEat 
            => new List<string>() { "Fruit", "Meat", "Seeds", "Vegetable"};

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
