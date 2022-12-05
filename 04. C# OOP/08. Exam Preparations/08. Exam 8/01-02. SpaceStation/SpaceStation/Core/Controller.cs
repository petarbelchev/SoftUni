using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int exploredPlanets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            exploredPlanets = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == nameof(Biologist))
                astronaut = new Biologist(astronautName);
            else if (type == nameof(Geodesist))
                astronaut = new Geodesist(astronautName);
            else if (type == nameof(Meteorologist))
                astronaut = new Meteorologist(astronautName);
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
                planet.Items.Add(item);

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (!suitableAstronauts.Any())
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);

            IPlanet planet = planets.FindByName(planetName);

            Mission mission = new Mission();

            mission.Explore(planet, suitableAstronauts);

            int diedAstronauts = suitableAstronauts.Count(a => a.Oxygen == 0);
            exploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName, diedAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var a in astronauts.Models)
            {
                var bagItems = a.Bag.Items.ToList();

                sb.AppendLine($"Name: {a.Name}");
                sb.AppendLine($"Oxygen: {a.Oxygen}");
                sb.AppendLine($"Bag items: {(bagItems.Any() ? string.Join(", ", bagItems) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
