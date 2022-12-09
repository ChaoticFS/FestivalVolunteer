using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;

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
            var result = httpClient.GetFromJsonAsync<User>($"api/user?userid={userid}");
            return result;
        }
        public Task PostUser(User user)
        {
            httpClient.PostAsJsonAsync<User>("api/user", user);
            return Task.CompletedTask;
        }
        public Task PutUser(User user)
        {
            httpClient.PutAsJsonAsync<User>("api/user", user);
            return Task.CompletedTask;
        }
        public Task DeleteUser(int userid)
        {
            httpClient.DeleteAsync($"api/user?userid={userid}");
            return Task.CompletedTask;
        }
    }
}