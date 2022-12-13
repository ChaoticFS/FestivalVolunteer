using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetFilteredShifts(Filter filter);
        IEnumerable<Shift> GetAllShifts();
        Shift GetShift(int shiftid);
        void PostShift(Shift shift);
        void DeleteShift(int shiftid);
        void PutShift(Shift shift);
    }
}

