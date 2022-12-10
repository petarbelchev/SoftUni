namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using Contracts;

    using System.Collections.Generic;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private ICollection<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models
            => (IReadOnlyCollection<IDelicacy>)models;

        public void AddModel(IDelicacy model)
            => models.Add(model);
    }
}
