using HouseRentingSystem.Services.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Services.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            return new Category[] {
                new Category()
                {
                    Id = 1,
                    Name = "Cottage"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Single-Family"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Duplex"
                }
            };
        }
    }
}
