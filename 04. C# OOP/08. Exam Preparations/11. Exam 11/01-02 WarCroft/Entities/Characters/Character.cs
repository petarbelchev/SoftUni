using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);

                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0) health = 0;
                else if (value > BaseHealth) health = BaseHealth;
                else health = value;
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value < 0) armor = 0;
                else armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double leftedHitPoints = Armor - hitPoints;

            if (leftedHitPoints >= 0)
            {
                Armor = leftedHitPoints;
            }
            else
            {
                Armor = 0;
                Health = Health + leftedHitPoints; // leftedHitPoints will be negative integer!

                if (Health == 0)
                    IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
        }
    }
}