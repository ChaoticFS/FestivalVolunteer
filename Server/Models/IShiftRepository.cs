using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IShiftRepository
    {
        List<Shift> GetFilteredShifts();
        Shift GetShift(int id);
        void PostShift(Shift shift);
        void DeleteShift(int id);
        void PutShift(Shift shift);
    }
}

