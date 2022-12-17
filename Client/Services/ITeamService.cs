using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Client.Services
{
    public interface ITeamService
    {
        Task<User[]> GetTeamMembers(int teamid);
        Task<Team[]> GetAllTeams();
        Task<Team> GetTeam(int teamid);
        Task PostTeam(Team team);
        Task DeleteTeam(int teamid);
        Task PutTeam(Team team);
    }
}
