using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<User> GetUser(int userid)
        {
            throw new NotImplementedException();
        }
        public Task PostUser(User user)
        {
            throw new NotImplementedException();
        }
        public Task PutUser(User user)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUser(int userid)
        {
            throw new NotImplementedException();
        }
    }
}