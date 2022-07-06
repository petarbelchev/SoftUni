﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dragons = new Dictionary<string, Dictionary<string, DragonStats>>();

            int numOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfDragons; i++)
            {
                string[] dragonDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string newDragonType = dragonDetails[0];
                string newDragonName = dragonDetails[1];
                var newDragonStats = new DragonStats(dragonDetails[2], dragonDetails[3], dragonDetails[4]);

                if (!dragons.ContainsKey(newDragonType))
                {
                    dragons.Add(newDragonType, new Dictionary<string, DragonStats>());
                    dragons[newDragonType].Add(newDragonName, newDragonStats);
                }
                else
                {
                    if (dragons[newDragonType].Keys.Contains(newDragonName))
                    {
                        dragons[newDragonType][newDragonName] = new DragonStats(dragonDetails[2], dragonDetails[3], dragonDetails[4]);
                    }
                    else
                    {
                        dragons[newDragonType].Add(newDragonName, newDragonStats);
                    }
                }
            }

            foreach (var type in dragons)
            {
                int dragonsCount = type.Value.Keys.Count();
                double sumDamage = 0;
                double sumHealth = 0;
                double sumArmor = 0;

                foreach (var dragon in type.Value)
                {
                    sumDamage += dragon.Value.Damage;
                    sumHealth += dragon.Value.Health;
                    sumArmor += dragon.Value.Armor;
                }

                Console.WriteLine($"{type.Key}::({sumDamage / dragonsCount:f2}/{sumHealth / dragonsCount:f2}/{sumArmor / dragonsCount:f2})");

                foreach (var dragon in type.Value.OrderBy(name => name.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }

    class DragonStats
    {
        public DragonStats(string damage, string health, string armor)
        {
            if (damage == "null")
            {
                Damage = 45;
            }
            else
            {
                Damage = int.Parse(damage);
            }

            if (health == "null")
            {
                Health = 250;
            }
            else
            {
                Health = int.Parse(health);
            }

            if (armor == "null")
            {
                Armor = 10;
            }
            else
            {
                Armor = int.Parse(armor);
            }
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
