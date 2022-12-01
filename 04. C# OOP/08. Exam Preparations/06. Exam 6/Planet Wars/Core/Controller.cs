namespace PlanetWars.Core
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Utilities.Messages;

    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit)
                    && unitTypeName != nameof(SpaceForces)
                    && unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            else
            {
                if (unitTypeName == nameof(AnonymousImpactUnit))
                {
                    var unit = new AnonymousImpactUnit();
                    planet.Spend(unit.Cost);
                    planet.AddUnit(unit);
                }
                else if (unitTypeName == nameof(SpaceForces))
                {
                    var unit = new SpaceForces();
                    planet.Spend(unit.Cost);
                    planet.AddUnit(unit);
                }
                else if (unitTypeName == nameof(StormTroopers))
                {
                    var unit = new StormTroopers();
                    planet.Spend(unit.Cost);
                    planet.AddUnit(unit);
                }

                return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            }
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                var weapon = new BioChemicalWeapon(destructionLevel);
                planet.Spend(weapon.Price);
                planet.AddWeapon(weapon);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                var weapon = new NuclearWeapon(destructionLevel);
                planet.Spend(weapon.Price);
                planet.AddWeapon(weapon);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                var weapon = new SpaceMissiles(destructionLevel);
                planet.Spend(weapon.Price);
                planet.AddWeapon(weapon);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.FirstOrDefault(p => p.Name == name) == default)
            {
                planets.AddItem(new Planet(name, budget));
                return string.Format(OutputMessages.NewPlanet, name);
            }

            return string.Format(OutputMessages.ExistingPlanet, name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var hasFirstPlanetNuclearWeapon = firstPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
            var secondPlanet = planets.FindByName(planetTwo);
            var hasSecondPlanetNuclearWeapon = secondPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
            var hasPlanetsSameMilitaryPower = firstPlanet.MilitaryPower == secondPlanet.MilitaryPower;

            IPlanet winner = default;
            IPlanet loser = default;

            if (hasPlanetsSameMilitaryPower)
            {
                if (hasFirstPlanetNuclearWeapon && !hasSecondPlanetNuclearWeapon)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else if (!hasFirstPlanetNuclearWeapon && hasSecondPlanetNuclearWeapon)
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }
            else
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }

            firstPlanet.Spend(firstPlanet.Budget / 2);
            secondPlanet.Spend(secondPlanet.Budget / 2);

            if (winner == default)
            {
                return string.Format(OutputMessages.NoWinner);
            }
            else
            {
                winner.Profit(loser.Budget);
                loser.Spend(loser.Budget);
                winner.Profit(loser.Army.Sum(u => u.Cost) + loser.Weapons.Sum(w => w.Price));
                planets.RemoveItem(loser.Name);

                return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            foreach (var u in planet.Army)
            {
                u.IncreaseEndurance();
            }

            planet.Spend(1.25);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
