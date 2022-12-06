using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            models = new HashSet<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models 
            => (IReadOnlyCollection<IEquipment>)models;

        public void Add(IEquipment model)
            => models.Add(model);

        public IEquipment FindByType(string type)
            => models.FirstOrDefault(e => e.GetType().Name == type);

        public bool Remove(IEquipment model)
            => models.Remove(model);
    }
}
