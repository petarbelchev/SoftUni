namespace PlanetWars.Models.Planets
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double sum = 0;
                sum += units.Models.Sum(u => u.EnduranceLevel);
                sum += weapons.Models.Sum(w => w.DestructionLevel);
                if (units.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
                {
                    sum *= 1.3;
                }
                if (weapons.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    sum *= 1.45;
                }
                return Math.Round(sum, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
            => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            string forces = units.Models.Count > 0 ? string.Join(", ", units.Models.Select(u => u.GetType().Name)) : "No units";
            sb.AppendLine($"--Forces: {forces}");
            string equipment = weapons.Models.Count > 0 ? string.Join(", ", weapons.Models.Select(w => w.GetType().Name)) : "No weapons";
            sb.AppendLine($"--Combat equipment: {equipment}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
            => Budget += amount;

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var u in units.Models)
            {
                u.IncreaseEndurance();
            }
        }
    }
}
