namespace FestivalVolunteer.Client.Services
{
    public class ShiftService : IShiftService
    {
        private readonly HttpClient httpClient;

        public ShiftService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
