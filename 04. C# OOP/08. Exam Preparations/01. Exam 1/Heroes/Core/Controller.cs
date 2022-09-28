using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Map;
using Heroes.Repositories;
using System;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weaponToAdd = this.weapons.Models.FirstOrDefault(w => w.Name == weaponName);

            if (weaponToAdd == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            IHero hero = this.heroes.Models.FirstOrDefault(w => w.Name == heroName);

            if (hero == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");

            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            hero.AddWeapon(weaponToAdd);

            this.weapons.Remove(weaponToAdd);

            return $"Hero {heroName} can participate in battle using a {weaponToAdd.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            Type heroType = Type.GetType($"Heroes.Models.Heroes.{type}");

            if (heroType == null)
                throw new InvalidOperationException("Invalid hero type.");

            if (/*heroes.Models.Any(m => m.Name == name)*/ this.heroes.FindByName(name) != null)
                throw new InvalidOperationException($"The hero {name} already exists.");
            try
            {
                IHero heroInstance = (IHero)Activator.CreateInstance(heroType, name, health, armour);
                this.heroes.Add(heroInstance);

                if (heroInstance.GetType().Name == "Knight")
                    return $"Successfully added Sir {heroInstance.Name} to the collection.";
                else
                    return $"Successfully added Barbarian {heroInstance.Name} to the collection.";
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            Type weaponType = Type.GetType($"Heroes.Models.Weapons.{type}");

            if (weaponType == null)
                throw new InvalidOperationException("Invalid weapon type.");

            if (/*weapons.Models.Any(m => m.Name == name)*/ this.weapons.FindByName(name) != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            try
            {
                IWeapon weaponInstance = (IWeapon)Activator.CreateInstance(weaponType, name, durability);

                this.weapons.Add(weaponInstance);

                return $"A {type.ToLower()} {name} is added to the collection.";
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public string HeroReport()
        {
            var sb = new StringBuilder();

            foreach (IHero hero in this.heroes.Models
                                              .OrderBy(h => h.GetType().Name)
                                              .ThenByDescending(h => h.Health)
                                              .ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine((hero.Weapon != null) ? $"--Weapon: {hero.Weapon.Name}" : "--Weapon: Unarmed");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(this.heroes.Models.ToArray());
        }
    }
}
