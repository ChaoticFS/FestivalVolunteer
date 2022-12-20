using FestivalVolunteer.Server.Models;
using FestivalVolunteer.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalVolunteer.Server.Controllers
{
    // Modtager HttpRequests fra services, sender requests til repositories og returnerer resultatet
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository Repository;
        public TeamController(ITeamRepository teamRepository)
        {
            if (Repository == null && teamRepository != null)
            {
                Repository = teamRepository;
            }
        }

        [HttpGet("members")]
        public IEnumerable<User> GetTeamMembers(int teamid)
        {
            return Repository.GetTeamMembers(teamid);
        }

        [HttpGet("teams")]
        public IEnumerable<Team> GetAllTeams()
        {
            return Repository.GetAllTeams();
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
