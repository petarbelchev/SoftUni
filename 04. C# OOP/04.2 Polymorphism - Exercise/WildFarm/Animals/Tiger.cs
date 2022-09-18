namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 1;

        public override IReadOnlyCollection<string> TypeOfFoodForEat 
            => new List<string>() { "Meat" };

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
