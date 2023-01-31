using HouseRentingSystem.Services.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Services.Data.Configurations
{
    public class AgentEntityTypeConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(SeedAgent());
        }

        private IEnumerable<Agent> SeedAgent()
        {
            return new Agent[] {
                new Agent()
                {
                    Id = 1,
                    PhoneNumber = "+359888888888",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                },
                new Agent()
                {
                    Id = 2,
                    PhoneNumber = "+359123456789",
                    UserId = "bcb4f072-ecca-43c9-ab26-c060c6f364e4"
                }
            };
        }
    }
}
