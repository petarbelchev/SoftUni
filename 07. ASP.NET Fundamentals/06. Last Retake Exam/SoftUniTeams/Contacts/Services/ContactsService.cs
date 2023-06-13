using Contacts.Data;
using Contacts.Data.Entities;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ContactsDbContext dbContext;

        public ContactsService(ContactsDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task AddContact(ContactFormModel model)
        {
            var contact = new Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website
            };

            await this.dbContext.Contacts.AddAsync(contact);
            await this.dbContext.SaveChangesAsync();
        }

        /// <exception cref="InvalidOperationException"></exception>
        public async Task AddUserContact(int contactId, string userId)
        {
            bool isHaveTheContact = await this.dbContext.ApplicationUsersContacts
                .AnyAsync(x => x.ApplicationUserId == userId && x.ContactId == contactId);

            if (isHaveTheContact)
                return;

            bool isContactExist = await this.dbContext.Contacts.AnyAsync(x => x.Id == contactId);

            if (!isContactExist)
                throw new InvalidOperationException();

            await this.dbContext.ApplicationUsersContacts
                .AddAsync(new ApplicationUserContact
                {
                    ApplicationUserId = userId,
                    ContactId = contactId
                });

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ContactsCollectionViewModel> AllContacts()
        {
            var viewModel = new ContactsCollectionViewModel
            {
                Contacts = await this.dbContext.Contacts
                    .Select(x => new ContactViewModel
                    {
                        ContactId = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Address = x.Address,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        Website = x.Website
                    })
                    .ToArrayAsync()
            };

            return viewModel;
        }

        /// <exception cref="InvalidOperationException"></exception>
        public async Task EditContact(int contactId, ContactFormModel model)
        {
            Contact? contact = await this.dbContext.Contacts.FindAsync(contactId) 
                ?? throw new InvalidOperationException();

			contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Address = model.Address;
            contact.Email = model.Email;
            contact.Website = model.Website;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ContactFormModel?> GetContactFormModel(int contactId)
        {
            ContactFormModel? model = await this.dbContext.Contacts
                .Where(x => x.Id == contactId)
                .Select(x => new ContactFormModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    Website = x.Website
                })
                .FirstOrDefaultAsync();

            return model;
        }

        /// <exception cref="InvalidOperationException"></exception>
        public async Task RemoveUserContact(int contactId, string userId)
        {
            bool isContactExist = await this.dbContext.Contacts.AnyAsync(x => x.Id == contactId);

            if (!isContactExist)
                throw new InvalidOperationException();

            ApplicationUserContact? userContact = await this.dbContext.ApplicationUsersContacts
                .Where(x => x.ApplicationUserId == userId && x.ContactId == contactId)
                .FirstOrDefaultAsync();

            if (userContact == null)
                return;

            this.dbContext.ApplicationUsersContacts.Remove(userContact);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ContactsCollectionViewModel> UserContacts(string userId)
        {
            var viewModel = new ContactsCollectionViewModel
            {
                Contacts = await this.dbContext.ApplicationUsersContacts
                .Where(x => x.ApplicationUserId == userId)
                .Select(x => new ContactViewModel
                {
                    ContactId = x.Contact.Id,
                    FirstName = x.Contact.FirstName,
                    LastName = x.Contact.LastName,
                    Address = x.Contact.Address,
                    Email = x.Contact.Email,
                    PhoneNumber = x.Contact.PhoneNumber,
                    Website = x.Contact.Website
                })
                .ToArrayAsync()
            };

            return viewModel;
        }
    }
}
