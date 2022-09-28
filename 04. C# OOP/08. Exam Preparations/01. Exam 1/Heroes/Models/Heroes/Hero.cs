using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Hero name cannot be null or empty.");

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Hero health cannot be below 0.");

                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Hero armour cannot be below 0.");

                this.armour = value;
            }
        }

        public IWeapon Weapon => this.weapon;

        public bool IsAlive => this.health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
                throw new ArgumentException("Weapon cannot be null.");

            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (this.Armour - points <= 0)
            {
                points = Math.Abs(this.Armour - points);
                this.Armour = 0;

                if (this.Health - points <= 0)
                    this.Health = 0;
                else
                    this.Health -= points;
            }
            else
                this.Armour -= points;
        }
    }
}
