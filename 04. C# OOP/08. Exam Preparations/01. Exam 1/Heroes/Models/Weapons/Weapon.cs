using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        private readonly int damage;

        public Weapon(string name, int durability, int damage)
        {
            this.Name = name;
            this.Durability = durability;
            this.damage = damage;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Weapon type cannot be null or empty.");

                this.name = value;
            }
        }

        public int Durability
        {
            get => this.durability;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Durability cannot be below 0.");

                this.durability = value;
            }
        }

        public int DoDamage()
        {
            if (this.Durability == 0)
                return this.Durability;

            this.Durability -= 1;

            return this.damage;
        }
    }
}
