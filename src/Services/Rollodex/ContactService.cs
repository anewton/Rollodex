using System.Threading.Tasks;
using Data.Models.Domain;
using Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Helpers;

namespace Services.Rollodex
{
    [Route("api/[controller]")]
    public class ContactService : Controller
    {
        private readonly IContactRepo _contactRepo;

        public ContactService(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [Route("Add")]
        public IActionResult AddContact()
        {
            return Ok();
        }

        [Route("Remove")]
        public IActionResult RemoveContact()
        {
            return Ok();
        }

        [Route("Update")]
        public IActionResult UpdateContact()
        {
            return Ok();
        }

        [Route("GetContactsForUser/{userId}/{pageIndex}/{pageSize}")]
        public async Task<PagedList<Contact>> GetAllContactsForUserPaged([FromRoute] int userId, [FromRoute] int pageIndex, [FromRoute] int pageSize)
        {
            var contactsQueryable = await _contactRepo.GetQueryableContactsForUserAsync(userId);
            var pagedContacts = PagedList<Contact>.Create(contactsQueryable, pageIndex, pageSize);
            return pagedContacts;
        }
    }
}