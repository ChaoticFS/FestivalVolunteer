using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface ITeamRepository
    {
        IEnumerable<User> GetTeamMembers(int teamid);
        IEnumerable<Team> GetAllTeams();
        Team GetTeam(int teamid);
        void PostTeam(Team team);
        void DeleteTeam(int teamid);
        void PutTeam(Team team);
    }
}
