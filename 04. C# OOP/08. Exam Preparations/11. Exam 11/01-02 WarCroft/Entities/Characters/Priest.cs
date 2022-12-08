using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double PriestHealth = 50;
        private const double PriestArmor = 25;
        private const double PriestAbilityPoints = 40;

        public Priest(string name)
            : base(name, PriestHealth, PriestArmor, PriestAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            character.Health += this.AbilityPoints;
        }
    }
}
