using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FestivalVolunteer.Client.Services
{
    // Bruges til at kommunikere mellem klient og server, Shift = vagt, UserShift = tilmelding
    public class ShiftService : IShiftService
    {
        private readonly HttpClient httpClient;

        public ShiftService(HttpClient httpClient)
        {
            this.httpClient = httpClient; //Modtager httpClient fra Program.cs
        }

        public Task<Shift[]?> GetFilteredShifts(Filter filter)
        {
            // Konverterer Filter til Json så man kan smide det med i linket
            string parameters = JsonSerializer.Serialize(filter);
            var result = httpClient.GetFromJsonAsync<Shift[]>($"api/shift/filter?parameters={parameters}");
            return result;
        }

        public Task<Shift> GetShift(int shiftid)
        {
            var result = httpClient.GetFromJsonAsync<Shift>($"api/shift?shiftid={shiftid}");
            return result;
        }

        public Task PostShift(Shift shift)
        {
            httpClient.PostAsJsonAsync<Shift>("api/shift", shift);
            return Task.CompletedTask;
        }

        public Task DeleteShift(int shiftid)
        {
            httpClient.DeleteAsync($"api/shift?shiftid={shiftid}");
            return Task.CompletedTask;
        }

        public Task PutShift(Shift shift)
        {
            httpClient.PutAsJsonAsync<Shift>("api/shift", shift);
            return Task.CompletedTask;
        }

        public async Task<UserShift[]> GetAllUsersForShift(int shiftid)
        {
            var result = await httpClient.GetFromJsonAsync<UserShift[]>($"api/shift/usershift/getusers?shiftid={shiftid}");
            return result;
        }

        public async Task<bool> GetUserShift(UserShift userShift)
        {
            string request = JsonSerializer.Serialize(userShift);
            var result = await httpClient.GetFromJsonAsync<bool>($"api/shift/usershift?usershift={request}");
            return result;
        }

        public async Task<Shift[]> GetAllShiftsForUser(int userid)
        {
            var result = await httpClient.GetFromJsonAsync<Shift[]>($"api/shift/usershift/getall?userid={userid}");
            return result;
        }

        public async Task<int> GetUserShiftCount(int shiftid)
        {
            var result = await httpClient.GetFromJsonAsync<int>($"api/shift/usershift/getcount?shiftid={shiftid}");
            return result;
        }

        public Task PostUserToShift(UserShift userShift)
        {
            httpClient.PostAsJsonAsync<UserShift>("api/shift/usershift", userShift);
            return Task.CompletedTask;
        }

        public Task DeleteUserShift(UserShift userShift)
        {
            string request = JsonSerializer.Serialize(userShift);
            httpClient.DeleteAsync($"api/shift/usershift?usershift={request}");
            return Task.CompletedTask;
        }
    }
}
