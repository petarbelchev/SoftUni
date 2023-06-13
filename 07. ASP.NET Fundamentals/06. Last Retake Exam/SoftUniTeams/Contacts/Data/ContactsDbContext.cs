using Contacts.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Contacts.Constants.UserConstants;

namespace Contacts.Data
{
	public class ContactsDbContext : IdentityDbContext<ApplicationUser>
	{
		public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
			: base(options)
		{
		}

		public DbSet<Contact> Contacts { get; set; } = null!;

		public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(x =>
			{
				x.Property(y => y.UserName).HasMaxLength(UserNameMaxLength).IsRequired();
				x.Property(y => y.NormalizedUserName).HasMaxLength(UserNameMaxLength).IsRequired();
				x.Property(y => y.Email).HasMaxLength(EmailMaxLength).IsRequired();
				x.Property(y => y.NormalizedEmail).HasMaxLength(EmailMaxLength).IsRequired();
			});

			builder.Entity<ApplicationUserContact>().HasKey(x => new { x.ApplicationUserId, x.ContactId });

			builder
				.Entity<Contact>()
				.HasData(new Contact()
				{
					Id = 1,
					FirstName = "Bruce",
					LastName = "Wayne",
					PhoneNumber = "+359881223344",
					Address = "Gotham City",
					Email = "imbatman@batman.com",
					Website = "www.batman.com"
				});
		}
	}
}