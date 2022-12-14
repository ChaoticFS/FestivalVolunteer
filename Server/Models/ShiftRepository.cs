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
            var sql = $"SELECT * " +
                      $"FROM shift " +
                      $"{ConstructWhereFromFilter(filter)}";

            Console.WriteLine(sql);

            return db.conn.Query<Shift>(sql);
        }

        public string? ConstructWhereFromFilter(Filter filter)
        {
            string whereString = "";
            List<string> filterList = new List<string>();

            if (filter.Date != null)
            {
                filterList.Add($"start_time={filter.Date}");
            }
            
            if (filter.Area != null) 
            { 
                filterList.Add($"area='{filter.Area}'"); 
            }

            if (filter.VolunteersNeeded != null) 
            { 
                filterList.Add($"volunteers_needed={filter.VolunteersNeeded}");
            }

            if (filter.Priority != null) 
            { 
                filterList.Add($"priority={filter.Priority}"); 
            }

            if (filter.Locked != null)  
            { 
                filterList.Add($"locked={filter.Locked}"); 
            }

            //filterList.Add($"team_id={filter.TeamId}");

            //filterList.Add($"user_id={filter.UserId}");

            int count = filterList.Count;
            if (count > 0)
            {
                whereString = "WHERE ";

                foreach (var parameter in filterList)
                {
                    whereString += $"{parameter}";

                    count--;
                    if (count > 0) 
                    {
                        whereString += " AND ";
                    }
                    
                }
            }
            return whereString;
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
            var sql = $"INSERT INTO shift(start_time, end_time, name, area, volunteers_needed, priority, locked) " +
                      $"VALUES (TIMESTAMP '{shift.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', TIMESTAMP '{shift.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{shift.Name}', '{shift.Area}', {shift.VolunteersNeeded}, {shift.Priority}, {shift.Locked})";
            
            db.conn.Execute(sql);
        }
        public void DeleteShift(int shiftid)
        {
            var sql = $"DELETE FROM shift " +
                      $"WHERE shift_id={shiftid}";

            db.conn.Execute(sql);
        }
        public void PutShift(Shift shift)
        {
            var sql = $"UPDATE shift " +
                      $"SET " +
                        $"start_time = {shift.StartTime}, " +
                        $"end_time = {shift.EndTime}, " +
                        $"name = {shift.Name}, " +
                        $"area = {shift.Area}, " +
                        $"volunteers_needed = {shift.VolunteersNeeded}, " +
                        $"priority = {shift.Priority}, " +
                        $"locked = {shift.Locked} " +
                      $"WHERE shift_id = {shift.ShiftId}";

            db.conn.Execute(sql);
        }
        public void PostUserToShift(UserShift userShift)
        {
            var sql = $"INSERT INTO user_shift(user_id, shift_id) " +
                      $"VALUES ({userShift.UserId}, {userShift.ShiftId})";

            db.conn.Execute(sql);
        }
        public void DeleteUserShift(int userid, int shiftid)
        {
            var sql = $"DELETE FROM user_shift " +
                      $"WHERE user_id={userid} " +
                      $"AND shift_id={shiftid}";

            db.conn.Execute(sql);
        }
    }
}
