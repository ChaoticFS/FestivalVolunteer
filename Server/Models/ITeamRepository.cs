using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface ITeamRepository
    {
        List<User> GetTeamMembers();
        Team GetTeam(int teamid);
        void PostTeam(Team team);
        void DeleteTeam(int teamid);
        void PutTeam(Team team);
    }
}
