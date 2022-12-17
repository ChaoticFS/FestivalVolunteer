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
        List<UserShift> GetAllUsersForShift(int shiftid);
        bool GetUserShift(int userid, int shiftid);
        List<Shift> GetAllShiftsForUser(int userid);
        void PostUserToShift(UserShift userShift);
        void DeleteUserShift(int userid, int shiftid);
    }
}

