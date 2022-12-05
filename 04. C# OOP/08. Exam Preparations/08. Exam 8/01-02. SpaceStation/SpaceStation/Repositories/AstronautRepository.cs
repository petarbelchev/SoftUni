using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new HashSet<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models 
            => (IReadOnlyCollection<IAstronaut>)astronauts;

        public void Add(IAstronaut model)
            => astronauts.Add(model);

        public IAstronaut FindByName(string name)
            => astronauts.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model)
            => astronauts.Remove(model);
    }
}
