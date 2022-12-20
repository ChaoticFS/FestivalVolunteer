using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    // Modtager kald fra controlleren, sender queries til databasen og returnerer resultatet
    internal class ShiftRepository : IShiftRepository
    {
        DBContext db;

        public ShiftRepository(DBContext context)
        {
            db = context;
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        /*
        Standard format for funktioner er følgende
        
        sql = @"(SELECT, INSERT INTO, etc) (*, parameter, etc)" +
              @"(FROM, VALUES, etc) (table, value, etc)"

        return db.conn.Query/Execute(sql)
        */

        // Tager et filter som parameter, bruger filteret til at generere "WHERE" delen af sql queryen gennem ConstructWhereFromFilter
        public IEnumerable<Shift> GetFilteredShifts(Filter filter)
        {
            try
            {
                var sql = $"SELECT * " +
                          $"FROM shift " +
                          $"{ConstructWhereFromFilter(filter)};";

                return db.conn.Query<Shift>(sql);
            }
            catch (Exception e )
            {
                return Enumerable.Empty<Shift>();
            }
        }

        // Laver "WHERE" delen af sql ud fra filteret
        public string? ConstructWhereFromFilter(Filter filter)
        {
            // Tom liste til WHERE delen
            List<string> filterList = new List<string>();

            // If statements på alle parametrene i filteret, tilføjer dem til listen til at generere den fulde string efter
            if (filter.Date != null)
            {
                // ::date konverterer start_time til dato så man kan få alle fra samme dag
                filterList.Add($"start_time::date ='{filter.Date.Value.ToString("yyyy-MM-dd")}'");
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

            filterList.Add($"team_id={filter.TeamId}");

            // Tom string til at tilføje parametrene til
            string whereString = "";

            // Counter så if statementen stopper med at tilføje "AND" når der ikke er flere elementer at tilføje
            int count = filterList.Count;
            if (count > 0)
            {
                whereString = "WHERE "; // Tilføjer WHERE før loopen så den starter med det og ikke gentager det

                // Tilføjer hver parameter til whereString fra
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
            var sql = $"INSERT INTO shift(start_time, end_time, name, area, volunteers_needed, priority, locked, team_id) " +
                      $"VALUES (TIMESTAMP '{shift.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', TIMESTAMP '{shift.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{shift.Name}', '{shift.Area}', {shift.VolunteersNeeded}, {shift.Priority}, {shift.Locked}, {shift.TeamId})";
            
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
                        $"start_time = TIMESTAMP '{shift.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                        $"end_time = TIMESTAMP '{shift.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                        $"name = '{shift.Name}', " +
                        $"area = '{shift.Area}', " +
                        $"volunteers_needed = {shift.VolunteersNeeded}, " +
                        $"priority = {shift.Priority}, " +
                        $"locked = {shift.Locked}, " +
                        $"team_id = {shift.TeamId} " +
                      $"WHERE shift_id = {shift.ShiftId}";

            db.conn.Execute(sql);
        }

        /*
        UserShift er en tilmelding til en vagt
        Den inkluderer shiftid og userid
        Hvis bruger og id eksisterer i samme entry betyder det en bruger er tilmeldt til en given vagt
        Derfor er der heller ikke nogen edit funktioner dertil da en ændring ikke giver mening
        */

        // Finder alle tilmeldinger til en given vagt
        public List<UserShift> GetAllUsersForShift(int shiftid)
        {
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE shift_id={shiftid};";

            List<UserShift> result = new List<UserShift>();

            // try-catch block til hvis der ikke er nogen tilmeldinger med given id
            try
            {
                var response = db.conn.Query<UserShift>(sql);
                result = response.ToList<UserShift>();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        // Returnerer true eller false, alt efter om tilmelding til vagt eksisterer
        public bool GetUserShift(int userid, int shiftid)
        {
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE user_id={userid} " +
                      $"AND shift_id={shiftid}";

            // try-catch, hvis tilmelding eksisterer, returner true, ellers returner false
            try
            {
                var result = db.conn.Query<UserShift>(sql).First();
                return result != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Finder alle vagter for en given bruger
        public List<Shift> GetAllShiftsForUser(int userid)
        {
            // Først finder den tilmeldinger for brugeren
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE user_id={userid}";

            List<Shift> result = new List<Shift>();

            // try-catch, hvis der er nogen tilmeldinger skaffer den alle vagterne og tilføjer til listen "result"
            try
            {
                var response = db.conn.Query<UserShift>(sql);

                foreach (var userShift in response)
                {
                    result.Add(GetShift(userShift.ShiftId));
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        // Tæller tilmeldinger til en vagt, bruges til at vise hvor mange tilmeldte ud af hvor mange der er behov for i html
        public int GetUserShiftCount(int shiftid)
        {
            var sql = $"SELECT COUNT(user_id) " +
                      $"FROM user_shift " +
                      $"WHERE shift_id={shiftid};";

            return db.conn.Query<int>(sql).First();
        }

        // Tilføjer en tilmelding med given bruger og vagt
        public void PostUserToShift(UserShift userShift)
        {
            try
            {
                var validationsql = $"SELECT * " +
                    $"FROM user_shift " +
                    $"WHERE user_id={userShift.UserId} " +
                    $"AND shift_id={userShift.ShiftId};";

                var result = db.conn.Query<UserShift>(validationsql).First();
            }
            catch (InvalidOperationException e)
            {
                var sql = $"INSERT INTO user_shift(user_id, shift_id) " +
                            $"VALUES ({userShift.UserId}, {userShift.ShiftId});";

                db.conn.Execute(sql);
            }
            finally
            {
                Console.WriteLine($"User posted to shift: {userShift.ShiftId}");
            }
        }

        // Sletter en tilmelding
        public void DeleteUserShift(int userid, int shiftid)
        {
            var sql = $"DELETE FROM user_shift " +
                      $"WHERE user_id={userid} " +
                      $"AND shift_id={shiftid}";

            db.conn.Execute(sql);
        }
    }
}
