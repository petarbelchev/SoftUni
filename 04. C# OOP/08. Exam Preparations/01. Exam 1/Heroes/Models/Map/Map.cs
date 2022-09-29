using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            ICollection<IHero> knights = players
                .Where(p => p.GetType() == typeof(Knight)).ToArray();

            ICollection<IHero> barbarians = players
                .Where(p => p.GetType() == typeof(Barbarian)).ToArray();

            int deathKnights = 0;
            int deathBarbarians = 0;

            while (knights.Any(k => k.Health > 0 && barbarians.Any(b => b.Health > 0)))
            {
                foreach (IHero knight in knights)
                {
                    if (knight.Health > 0 && knight.Weapon != null)
                    {
                        foreach (IHero barbarian in barbarians)
                        {
                            if (barbarian.Health > 0 && barbarian.Weapon != null)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());

                                if (barbarian.Health == 0) 
                                    deathBarbarians++;
                            }
                        }
                    }
                }

                foreach (IHero barbarian in barbarians)
                {
                    if (barbarian.Health > 0 && barbarian.Weapon != null)
                    {
                        foreach (IHero knight in knights)
                        {
                            if (knight.Health > 0 && knight.Weapon != null)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());

                                if (knight.Health == 0)
                                    deathKnights++;
                            }
                        }
                    }
                }
            }

            if (barbarians.Any(b => b.Health > 0) == false)
                return $"The knights took {deathKnights} casualties but won the battle.";
            else
                return $"The barbarians took {deathBarbarians} casualties but won the battle.";
        }
    }
}
