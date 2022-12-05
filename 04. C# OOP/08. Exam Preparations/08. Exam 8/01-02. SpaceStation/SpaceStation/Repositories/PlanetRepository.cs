using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new HashSet<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)planets;

        public void Add(IPlanet model)
            => planets.Add(model);

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPlanet model)
            => planets.Remove(model);
    }
}
