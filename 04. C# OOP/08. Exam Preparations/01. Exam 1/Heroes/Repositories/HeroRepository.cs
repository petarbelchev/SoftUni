using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        ICollection<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.models.ToImmutableArray();

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name)
            => this.models.FirstOrDefault(models => models.Name == name);

        public bool Remove(IHero model)
        {
            IHero modelToRemove = this.models.FirstOrDefault(models => models.Name == model.Name);

            if (modelToRemove == null)
                return false;

            this.models.Remove(modelToRemove);

            return true;
        }
    }
}
