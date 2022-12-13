using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    internal class ShiftRepository : IShiftRepository
    {
        DBContext db;

        public ShiftRepository()
        {
            this.db = new DBContext();
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IEnumerable<Shift> GetFilteredShifts(Filter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            var sql = $"SELECT * " +
                      $"FROM shift";

            return db.conn.Query<Shift>(sql);
        }

        public Shift GetShift(int shiftid)
        {
            var sql = $"SELECT * " +
                      $"FROM shift " +
                      $"WHERE shift_id={shiftid}";

            return db.conn.Query<Shift>(sql).First();
        }
        public void PostShift(Shift shift)
        {
            var sql = $"INSERT INTO shift (start_time, end_time, name, area, volunteers_needed, priority, locked)" +
                      $"VALUES (@StartTime, @EndTime, @Name, @Area, @VolunteersNeeded, @Priority, @Locked)";

            db.conn.Execute(sql);
        }
        public void DeleteShift(int shiftid)
        {
            var sql = $"DELETE FROM shift" +
                      $"WHERE shift_id={shiftid}";

            db.conn.Execute(sql);
        }
        public void PutShift(Shift shift)
        {
            var sql = $"UPDATE shift" +
                      $"SET " +
                        $"start_time = @StartTime," +
                        $"end_time = @EndTime" +
                        $"name = @Name" +
                        $"area = @Area" +
                        $"volunteers_needed = @VolunteersNeeded" +
                        $"priority = @Priority" +
                        $"locked = @Locked" +
                      $"WHERE shift_id = @ShiftId";

            db.conn.Execute(sql);
        }
    }
}
