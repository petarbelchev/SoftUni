namespace AquaShop.Repositories
{
    using Contracts;
    using Models.Decorations.Contracts;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models 
            => this.models.ToImmutableList();

        public void Add(IDecoration model) 
            => this.models.Add(model);

        public IDecoration FindByType(string type) 
            => this.models.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IDecoration model) 
            => this.models.Remove(model);
    }
}
