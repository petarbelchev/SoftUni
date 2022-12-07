using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs;

        public EggRepository()
        {
            eggs = new HashSet<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
            => (IReadOnlyCollection<IEgg>)eggs;

        public void Add(IEgg egg)
            => eggs.Add(egg);

        public IEgg FindByName(string name)
            => eggs.FirstOrDefault(b => b.Name == name);

        public bool Remove(IEgg egg)
            => eggs.Remove(egg);
    }
}
