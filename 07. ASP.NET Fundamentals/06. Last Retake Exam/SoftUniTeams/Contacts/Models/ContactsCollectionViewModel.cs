namespace Contacts.Models
{
    public class ContactsCollectionViewModel
    {
        public IEnumerable<ContactViewModel> Contacts { get; set; }
            = new List<ContactViewModel>();
    }
}
