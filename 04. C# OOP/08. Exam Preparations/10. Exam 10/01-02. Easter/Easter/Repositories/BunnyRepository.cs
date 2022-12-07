using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new HashSet<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models 
            => (IReadOnlyCollection<IBunny>)bunnies;

        public void Add(IBunny bunny)
            => bunnies.Add(bunny);

        public IBunny FindByName(string name)
            => bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny bunny)
            => bunnies.Remove(bunny);
    }
}
