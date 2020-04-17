using Microsoft.AspNetCore.Mvc;
using Data.Models.Service;
using Data.Repo;
using System.Threading.Tasks;

namespace Services.Identity
{
    public class UserService : Controller
    {
        private readonly IUserRepo _userRepo;
        
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [Route("/Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistration userRegistration)
        {
            await _userRepo.RegisterUserAsync(userRegistration.UserName);
            return Ok();
        }
    }
}