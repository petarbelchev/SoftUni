namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using Contracts;

    using System.Collections.Generic;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private ICollection<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models
            => (IReadOnlyCollection<ICocktail>)models;

        public void AddModel(ICocktail model)
            => models.Add(model);
    }
}
