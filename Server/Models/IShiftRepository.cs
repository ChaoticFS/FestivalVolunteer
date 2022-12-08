using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IShiftRepository
    {
        List<Shift> GetFilteredShifts();
        Shift GetShift(int shiftid);
        void PostShift(Shift shift);
        void DeleteShift(int shiftid);
        void PutShift(Shift shift);
    }
}

