using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HouseRentingSystem.Services.Data.DataConstants.AdminConstants;

namespace HouseRentingSystem.Services.Data.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private IEnumerable<User> SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

            var users = new List<User>();

            var agentUser = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Linda",
                LastName = "Michaels"
            };

            agentUser.PasswordHash = hasher.HashPassword(agentUser, "agent123");

            users.Add(agentUser);

            var guestUser = new User()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "GUEST@MAIL.COM",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Teodor",
                LastName = "Lesly"
            };

            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest123");

            users.Add(guestUser);

            var adminUser = new User()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                FirstName = "Great",
                LastName = "Admin"
            };

            adminUser.PasswordHash = hasher.HashPassword(agentUser, "admin123");

            users.Add(adminUser);

            return users;
        }
    }
}
