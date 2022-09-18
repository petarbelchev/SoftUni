namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => 0.25;

        public override IReadOnlyCollection<string> TypeOfFoodForEat
            => new List<string>() { "Meat" };

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
