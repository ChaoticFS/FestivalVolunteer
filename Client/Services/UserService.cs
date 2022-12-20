using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;

namespace FestivalVolunteer.Client.Services
{
    // Bruges til at kommunikere mellem klient og server
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient; //Modtager httpClient fra Program.cs
        }

        public Task<User> GetUser(int userid)
        {
            var result = httpClient.GetFromJsonAsync<User>($"api/user?userid={userid}");
            return result;
        }
        public async Task<int> PostUser(User user)
        {
            Console.WriteLine("Post user called");
            var response = await httpClient.PostAsJsonAsync<User>("api/user", user);
            string result = await response.Content.ReadAsStringAsync();
            return int.Parse(result);
        }
        public async Task PutUser(User user)
        {
            await httpClient.PutAsJsonAsync<User>("api/user", user);
        }
        public Task DeleteUser(int userid)
        {
            httpClient.DeleteAsync($"api/user?userid={userid}");
            return Task.CompletedTask;
        }
    }
}