using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models.ToImmutableArray();

        public void Add(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
            => this.models.FirstOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model)
        {
            IWeapon modelToRemove = this.models.FirstOrDefault(models => models.Name == model.Name);

            if (modelToRemove == null)
                return false;

            this.models.Remove(modelToRemove);

            return true;
        }
    }
}
