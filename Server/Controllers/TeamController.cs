using FestivalVolunteer.Server.Models;
using FestivalVolunteer.Shared.Models;
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

        [HttpGet("members")]
        public IEnumerable<User> GetTeamMembers(int teamid)
        {
            return Repository.GetTeamMembers(teamid);
        }

        [HttpGet]
        public Team GetTeam(int teamid)
        {
            return Repository.GetTeam(teamid);
        }

        [HttpPost]
        public void PostTeam(Team team)
        {
            Repository.PostTeam(team);
        }

        [HttpPut]
        public void PutTeam(Team team)
        {
            Repository.PutTeam(team);
        }

        [HttpDelete]
        public void DeleteTeam(int teamid)
        {
            Repository.DeleteTeam(teamid);
        }
    }
}
