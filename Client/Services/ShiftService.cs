using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FestivalVolunteer.Client.Services
{
    public class ShiftService : IShiftService
    {
        private readonly HttpClient httpClient;

        public ShiftService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Shift[]?> GetFilteredShifts(Filter filter)
        {
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

        public Task PostUserToShift(UserShift userShift)
        {
            httpClient.PostAsJsonAsync<UserShift>("api/shift/usershift", userShift);
            return Task.CompletedTask;
        }

        public Task DeleteUserShift(UserShift userShift)
        {
            httpClient.DeleteAsync($"api/shift/usershift?userid={userShift.UserId},shiftid={userShift.ShiftId}");
            return Task.CompletedTask;
        }
    }
}
