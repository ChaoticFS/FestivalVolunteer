using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetFilteredShifts(Filter filter);
        Shift GetShift(int shiftid);
        void PostShift(Shift shift);
        void DeleteShift(int shiftid);
        void PutShift(Shift shift);
        IEnumerable<UserShift> GetUserShift(int userid, int shiftid);
        void PostUserToShift(UserShift userShift);
        void DeleteUserShift(int userid, int shiftid);
    }
}

