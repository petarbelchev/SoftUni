namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            double leftOxygen = this.Oxygen - 5;

            if (leftOxygen < 0)
                this.Oxygen = 0;
            else
                this.Oxygen = leftOxygen;
        }
    }
}
