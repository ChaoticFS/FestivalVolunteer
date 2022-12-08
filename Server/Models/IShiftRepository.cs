using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IShiftRepository
    {
        List<Shift> GetFilteredShifts();
        Shift GetShift(string id);
        void PostShift(Shift shift);
        void DeleteShift(string id);
        void PutShift(Shift shift);
    }
}

