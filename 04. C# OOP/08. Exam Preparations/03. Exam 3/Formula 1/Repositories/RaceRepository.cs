using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
            => (IReadOnlyCollection<IRace>)this.models;

        public void Add(IRace race)
            => this.models.Add(race);

        public IRace FindByName(string raceName)
            => this.models.FirstOrDefault(m => m.RaceName == raceName);

        public bool Remove(IRace race)
            => this.models.Remove(race);
    }
}
