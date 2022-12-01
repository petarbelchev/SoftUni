namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.Planets.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)planets;

        public void AddItem(IPlanet model)
            => planets.Add(model);

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(p => p.Name == name);

        public bool RemoveItem(string name)
            => planets.Remove(FindByName(name));
    }
}
