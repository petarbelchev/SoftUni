using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
            => this.contactsService = contactsService;

        [HttpGet]
        public IActionResult Add()
            => this.View(new ContactFormModel());

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
                return this.View(model);

            await this.contactsService.AddContact(model);

            return this.RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await this.contactsService.AddUserContact(contactId, userId);
            }
            catch (InvalidOperationException)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ContactsCollectionViewModel viewModel = await this.contactsService.AllContacts();

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            ContactFormModel? viewModel =
                await this.contactsService.GetContactFormModel(contactId);

			return viewModel == null 
                ? this.BadRequest() 
                : this.View(viewModel);
		}

		[HttpPost]
        public async Task<IActionResult> Edit(int contactId, ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
                return this.View(model);

            try
            {
                await this.contactsService.EditContact(contactId, model);
            }
            catch (InvalidOperationException)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ContactsCollectionViewModel viewModel = await this.contactsService.UserContacts(userId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            try
            {
                await this.contactsService.RemoveUserContact(contactId, userId);
            }
            catch (InvalidOperationException)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(Team));
        }
    }
}
