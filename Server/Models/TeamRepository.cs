using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public class TeamRepository : ITeamRepository
    {
        public List<User> GetTeamMembers()
        {
            throw new NotImplementedException();
        }
        public Team GetTeam(int teamid)
        {
            throw new NotImplementedException();
        }
        public void PostTeam(Team team)
        {
            throw new NotImplementedException();
        }
        public void DeleteTeam(int teamid)
        {
            throw new NotImplementedException();
        }
        public void PutTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
