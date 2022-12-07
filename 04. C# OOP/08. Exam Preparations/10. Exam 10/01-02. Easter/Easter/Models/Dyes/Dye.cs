using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power; 
            private set
            {
                power = value;
                if (power < 0)
                {
                    power = 0;
                }
            }
        }

        public bool IsFinished()
            => Power == 0;

        public void Use()
            => Power -= 10;
    }
}
