namespace Formula1.Repositories
{
    using Contracts;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
            => (IReadOnlyCollection<IPilot>)this.models;

        public void Add(IPilot pilot)
            => this.models.Add(pilot);

        public IPilot FindByName(string fullName)
            => this.models.FirstOrDefault(m => m.FullName == fullName);

        public bool Remove(IPilot pilot)
            => this.models.Remove(pilot);
    }
}
