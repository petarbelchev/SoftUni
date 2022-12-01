namespace PlanetWars.Models.MilitaryUnits
{
    using Contracts;
    using System;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            if (EnduranceLevel == 20)
            {
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }

            EnduranceLevel++;
        }
    }
}
