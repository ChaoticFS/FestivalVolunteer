using FestivalVolunteer.Server.Models;
using FestivalVolunteer.Shared.Models;
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

        [HttpGet]
        public User GetUser(int userid)
        {
            return Repository.GetUser(userid);
        }

        [HttpPost]
        public int PostUser(User user)
        {
            var result = Repository.PostUser(user);
            return result;
        }

        [HttpPut]
        public void PutUser(User user)
        {
            Repository.PutUser(user);
        }

        [HttpDelete]
        public void DeleteUser(int userid)
        {
            Repository.DeleteUser(userid);
        }
    }
}
