using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Client.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient httpClient;

        public TeamService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<User[]> GetTeamMembers(int teamid)
        {
            throw new NotImplementedException();
        }
        public Task<Team> GetTeam(int teamid)
        {
            throw new NotImplementedException();
        }
        public Task PostTeam(Team team) 
        { 
            throw new NotImplementedException(); 
        }
        public Task DeleteTeam(int teamid)
        {
            throw new NotImplementedException();
        }
        public Task PutTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}