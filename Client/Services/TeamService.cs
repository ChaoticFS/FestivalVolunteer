namespace FestivalVolunteer.Client.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient httpClient;

        public TeamService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}