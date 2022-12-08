using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    internal class ShiftRepository : IShiftRepository
    {
        DBContext dbShift = new DBContext();

        public List<Shift> GetFilteredShifts()
        {
            throw new NotImplementedException();
        }
        public Shift GetShift(string id)
        {
            throw new NotImplementedException();
        }
        public void PostShift(Shift shift)
        {
            throw new NotImplementedException();
        }
        public void DeleteShift(string id)
        {
            throw new NotImplementedException();
        }
        public void PutShift(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
