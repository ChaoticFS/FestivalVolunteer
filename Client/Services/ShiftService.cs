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
            throw new NotImplementedException();
        }
        public Task PostShift(Shift shift)
        {
            throw new NotImplementedException();
        }
        public Task DeleteShift(int shiftid)
        {
            throw new NotImplementedException();
        }
        public Task PutShift(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
