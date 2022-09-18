namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override IReadOnlyCollection<string> TypeOfFoodForEat
            => new List<string>() { "Vegetable", "Meat" };

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
