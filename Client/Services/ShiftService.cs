using FestivalVolunteer.Shared.Models;
using System.Net.Http.Json;

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
            string passfilterparameter = "hvordan i alverden";
            var result = httpClient.GetFromJsonAsync<Shift[]>("api/shift/filter");
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
