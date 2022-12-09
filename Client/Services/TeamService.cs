using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;

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
            var result = httpClient.GetFromJsonAsync<User[]>($"api/team/members?teamid={teamid}");
            return result;
        }
        public Task<Team> GetTeam(int teamid)
        {
            var result = httpClient.GetFromJsonAsync<Team>($"api/team?teamid={teamid}");
            return result;
        }
        public Task PostTeam(Team team) 
        {
            httpClient.PostAsJsonAsync<Team>("api/team", team);
            return Task.CompletedTask;
        }
        public Task DeleteTeam(int teamid)
        {
            httpClient.DeleteAsync($"api/team?teamid={teamid}");
            return Task.CompletedTask;
        }
        public Task PutTeam(Team team)
        {
            httpClient.PutAsJsonAsync<Team>("api/team", team);
            return Task.CompletedTask;
        }
    }
}