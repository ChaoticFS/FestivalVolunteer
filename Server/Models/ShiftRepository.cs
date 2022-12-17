﻿using Dapper;
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
            try
            {
                var sql = $"SELECT * " +
                              $"FROM shift " +
                              $"{ConstructWhereFromFilter(filter)};";

                return db.conn.Query<Shift>(sql);
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                return Enumerable.Empty<Shift>();
            }
        }

        public string? ConstructWhereFromFilter(Filter filter)
        {
            string whereString = "";
            List<string> filterList = new List<string>();

            if (filter.Date != null)
            {
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

            Console.WriteLine(sql);

            db.conn.Execute(sql);
        }

        public List<UserShift> GetAllUsersForShift(int shiftid)
        {
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE shift_id={shiftid};";

            List<UserShift> result = new List<UserShift>();

            try
            {
                var response = db.conn.Query<UserShift>(sql);
                result = response.ToList<UserShift>();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }
        }

        public bool GetUserShift(int userid, int shiftid)
        {
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE user_id={userid} " +
                      $"AND shift_id={shiftid}";
            try
            {
                var result = db.conn.Query<UserShift>(sql).First();
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Shift> GetAllShiftsForUser(int userid)
        {
            var sql = $"SELECT * " +
                      $"FROM user_shift " +
                      $"WHERE user_id={userid}";

            List<Shift> result = new List<Shift>();

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
                Console.WriteLine(sql, ex);
                return result;
            }
        }

        public int GetUserShiftCount(int shiftid)
        {
            var sql = $"SELECT COUNT(user_id) " +
                      $"FROM user_shift " +
                      $"WHERE shift_id={shiftid};";

            return db.conn.Query<int>(sql).First();
        }

        public void PostUserToShift(UserShift userShift)
        {
            try
            {
                var validationsql = $"SELECT * " +
                    $"FROM user_shift " +
                    $"WHERE user_id={userShift.UserId} " +
                    $"AND shift_id={userShift.ShiftId};";

                Console.WriteLine(validationsql);

                var result = db.conn.Query<UserShift>(validationsql).First();
            }
            catch (InvalidOperationException e)
            {
                var sql = $"INSERT INTO user_shift(user_id, shift_id) " +
                            $"VALUES ({userShift.UserId}, {userShift.ShiftId});";

                Console.WriteLine(e.Message, sql);

                db.conn.Execute(sql);
            }
            finally
            {
                Console.WriteLine($"User posted to shift: {userShift.ShiftId}");
            }
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
