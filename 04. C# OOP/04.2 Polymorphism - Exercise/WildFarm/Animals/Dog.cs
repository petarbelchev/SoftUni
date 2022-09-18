namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => 0.40;

        public override IReadOnlyCollection<string> TypeOfFoodForEat
            => new List<string>() { "Meat" };

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
