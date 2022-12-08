using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    internal class ShiftRepository : IShiftRepository
    {
        DBContext dbShift = new DBContext();

        public List<Shift> GetFilteredShifts(Filter filter)
        {
            throw new NotImplementedException();
        }
        public Shift GetShift(int shiftid)
        {
            throw new NotImplementedException();
        }
        public void PostShift(Shift shift)
        {
            throw new NotImplementedException();
        }
        public void DeleteShift(int shiftid)
        {
            throw new NotImplementedException();
        }
        public void PutShift(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
