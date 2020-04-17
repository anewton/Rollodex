using System.Threading.Tasks;
using Data.Models.Domain;
using Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Helpers;

namespace Services.Rollodex
{
    public class ContactService : Controller
    {
        private readonly IContactRepo _contactRepo;

        public ContactService(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public IActionResult AddContact()
        {
            return Ok();
        }

        public IActionResult RemoveContact()
        {
            return Ok();
        }

        public IActionResult UpdateContact()
        {
            return Ok();
        }

        public async Task<PagedList<Contact>> GetAllContactsForUserPaged(int userId, int pageIndex, int pageSize)
        {
            var contactsQueryable = await _contactRepo.GetQueryableContactsForUserAsync(userId);
            var pagedContacts = await PagedList<Contact>.CreateAsync(contactsQueryable.AsNoTracking(), pageIndex, pageSize);
            return pagedContacts;
        }
    }
}