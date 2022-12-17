using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Client.Services
{
    public interface IShiftService
    {
        Task<Shift[]?> GetFilteredShifts(Filter filter);
        Task<Shift> GetShift(int shiftid);
        Task PostShift(Shift shift);
        Task DeleteShift(int shiftid);
        Task PutShift(Shift shift);
        Task<UserShift[]> GetAllUsersForShift(int shiftid);
        Task<bool> GetUserShift(UserShift userShift);
        Task<Shift[]> GetAllShiftsForUser(int userid);
        Task PostUserToShift(UserShift userShift);
        Task DeleteUserShift(UserShift userShift);
    }
}
