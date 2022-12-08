namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarCroft.Constants;
    using WarCroft.Entities.Characters;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Items;

    public class WarController
    {
        private ICollection<Character> party;
        private ICollection<Item> pool;

        public WarController()
        {
            party = new List<Character>();
            pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = null;

            if (characterType == nameof(Warrior))
                character = new Warrior(name);
            else if (characterType == nameof(Priest))
                character = new Priest(name);
            else
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));

            party.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;

            if (itemName == nameof(FirePotion))
                item = new FirePotion();
            else if (itemName == nameof(HealthPotion))
                item = new HealthPotion();
            else
                throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);

            pool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);

            if (!pool.Any())
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);

            var item = pool.Last();
            pool.Remove(item);
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));

            Item item = character.Bag.GetItem(itemName);
            if (item == null)
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));

            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var c in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {(c.IsAlive ? "Alive" : "Dead")}");

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = party.FirstOrDefault(c => c.Name == attackerName);
            if (attacker == null)
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);

            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);

            if (!attacker.IsAlive || !receiver.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            receiver.TakeDamage(attacker.AbilityPoints);

            string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
                result += Environment.NewLine + $"{receiver.Name} is dead!";

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = party.FirstOrDefault(c => c.Name == healerName);
            if (healer == null)
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);

            Character receiver = party.FirstOrDefault(c => c.Name == healingReceiverName);
            if (receiver == null)
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);

            if (!healer.IsAlive || healer.GetType().Name != nameof(Priest))
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));

            (healer as Priest).Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
