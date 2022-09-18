namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => 0.10;

        public override IReadOnlyCollection<string> TypeOfFoodForEat
            => new List<string>() { "Vegetable", "Fruit" };


        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
