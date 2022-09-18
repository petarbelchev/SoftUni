using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            ICollection<BaseHero> heroes = new List<BaseHero>();
            string[] heroTypes = new string[] { "Druid", "Paladin", "Rogue", "Warrior" };

            for (int i = 0; i < lines; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (!heroTypes.Contains(heroType))
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                else if (heroType == "Druid")
                {
                    heroes.Add(new Druid(heroName));
                }
                else if (heroType == "Paladin")
                {
                    heroes.Add(new Paladin(heroName));
                }
                else if (heroType == "Rogue")
                {
                    heroes.Add(new Rogue(heroName));
                }
                else if (heroType == "Warrior")
                {
                    heroes.Add(new Warrior(heroName));
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int sumPower = 0;

            foreach (var hero in heroes)
            {
                sumPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
