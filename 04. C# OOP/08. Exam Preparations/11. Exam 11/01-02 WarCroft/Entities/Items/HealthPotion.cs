using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPotionWeight = 5;

        public HealthPotion()
            : base(HealthPotionWeight)
        {}

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            character.Health += 20;
        }
    }
}
