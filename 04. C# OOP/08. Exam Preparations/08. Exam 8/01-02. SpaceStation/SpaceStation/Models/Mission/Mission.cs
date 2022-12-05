using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> items = planet.Items.ToList();

            foreach (var astronaut in astronauts.Where(a => a.CanBreath))
            {
                if (!items.Any())
                    break;

                while (items.Any() && astronaut.CanBreath)
                {
                    astronaut.Bag.Items.Add(items[0]);
                    astronaut.Breath();
                    items.RemoveAt(0);
                }
            }
        }
    }
}
