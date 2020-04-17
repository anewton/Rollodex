using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models.Domain;
using Data.RepoBase;
using Microsoft.EntityFrameworkCore;

namespace Data.Repo
{
    public interface IContactRepo : IDbRepository
    {
        Task<IQueryable<Contact>> GetQueryableContactsForUserAsync(int userId);
        Task<IEnumerable<Contact>> PageAllForUserAsync(int userId, int skip, int take);
    }

    public class ContactRepo : DbRepository, IContactRepo
    {
        public ContactRepo(SiteContext context) : base(context)
        {

        }

        public async Task<IQueryable<Contact>> GetQueryableContactsForUserAsync(int userId)
        {
            var context = (SiteContext)_dbContext;
            var result = await (from c in context.Contacts
                                join uc in context.UserContacts
                                on c.Id equals uc.ContactId
                                where uc.Id == userId
                                select c).ToListAsync();
            return result.AsQueryable();
        }

        public async Task<IEnumerable<Contact>> PageAllForUserAsync(int userId, int skip, int take)
        {
            var context = (SiteContext)_dbContext;
            var result = await (from c in context.Contacts
                                join uc in context.UserContacts
                                on c.Id equals uc.ContactId
                                where uc.Id == userId
                                select c).Skip(skip).Take(take).ToListAsync();
            return result.AsEnumerable<Contact>();
        }
    }
}