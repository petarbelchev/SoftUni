using Contacts.Models;

namespace Contacts.Services
{
    public interface IContactsService
    {
        Task AddContact(ContactFormModel model);

        /// <exception cref="InvalidOperationException"></exception>
        Task AddUserContact(int contactId, string userId);

        Task<ContactsCollectionViewModel> AllContacts();

        /// <exception cref="InvalidOperationException"></exception>
        Task EditContact(int contactId, ContactFormModel model);

        Task<ContactFormModel?> GetContactFormModel(int contactId);

        /// <exception cref="InvalidOperationException"></exception>
        Task RemoveUserContact(int contactId, string userId);

        Task<ContactsCollectionViewModel> UserContacts(string userId);
    }
}
