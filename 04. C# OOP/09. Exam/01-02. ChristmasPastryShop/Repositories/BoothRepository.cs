namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using Contracts;

    using System.Collections.Generic;

    public class BoothRepository : IRepository<IBooth>
    {
        private ICollection<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models
            => (IReadOnlyCollection<IBooth>)models;

        public void AddModel(IBooth model)
            => models.Add(model);
    }
}
