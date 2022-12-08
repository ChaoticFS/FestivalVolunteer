using FestivalVolunteer.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalVolunteer.Server.Controllers
{
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository Repository = new TeamRepository();
        public TeamController(ITeamRepository teamRepository)
        {
            if (Repository == null && teamRepository != null)
            {
                Repository = teamRepository;
                Console.WriteLine("Repository initialized");
            }
        }
    }
}
