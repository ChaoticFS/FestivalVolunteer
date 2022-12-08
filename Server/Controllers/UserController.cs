using FestivalVolunteer.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalVolunteer.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository Repository = new UserRepository();
        public UserController(IUserRepository userRepository)
        {
            if (Repository == null && userRepository != null)
            {
                Repository = userRepository;
                Console.WriteLine("Repository initialized");
            }
        }
    }
}
