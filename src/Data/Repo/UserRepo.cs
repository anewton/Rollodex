using System.Linq;
using System.Threading.Tasks;
using Data.Models.Domain;
using Data.RepoBase;

namespace Data.Repo
{
    public interface IUserRepo
    {
        Task<int> RegisterUserAsync(string userName);
    }

    public class UserRepo : DbRepository, IUserRepo
    {
        public UserRepo(SiteContext context) : base(context)
        {

        }

        public async Task<int> RegisterUserAsync(string userName)
        {
            var context = (SiteContext)_dbContext;
            var user = context.Users.Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
            if (user == null)
            {
                var newUser = await _dbContext.AddAsync<SiteUser>(new SiteUser() { UserName = userName });
                await _dbContext.SaveChangesAsync();
                return newUser.Entity.Id;
            }
            else
            {
                return user.Id;
            }
        }

    }
}