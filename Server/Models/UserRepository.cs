﻿using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    // Modtager kald fra controlleren, sender queries til databasen og returnerer resultatet
    public class UserRepository : IUserRepository
    {
        DBContext db;

        public UserRepository(DBContext context)
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

        // Tjekker om en nullable int er null og returnerer "null" hvis true, så sqlen stadig fungerer når de er null
        public string IsNull(int? property)
        {
            if (property == null)
            {
                return "null";
            }
            else
            {
                return $"{property}";
            }
        }

        public User GetUser(int userid)
        {
            var sql = $"SELECT * " +
                      $"FROM users " +
                      $"WHERE user_id={userid}";

            return db.conn.Query<User>(sql).First();
        }
        
        public int PostUser(User user)
        {
            var sql = $"INSERT INTO users(user_id, role_id, team_id, name, birthday, email, experience, is_active, group_id) " +
                      $"VALUES (DEFAULT, {user.RoleId}, {IsNull(user.TeamId)}, '{user.Name}', '{user.Birthday.ToString("yyyy-MM-dd")}', '{user.Email}', '{user.Experience}', {user.IsActive}, {IsNull(user.GroupId)}) " +
                      $"RETURNING user_id";

            return db.conn.Query<int>(sql).First();
        }

        public void DeleteUser(int userid)
        {
            var sql = $"DELETE FROM users " +
                      $"WHERE user_id={userid}";

            db.conn.Execute(sql);
        }

        // Edit user
        public void PutUser(User user)
        {
            var sql = $"UPDATE users " +
                      $"SET " +
                        $"role_id={user.RoleId}, " +
                        $"team_id={IsNull(user.TeamId)}, " +
                        $"name='{user.Name}', " +
                        $"birthday='{user.Birthday.ToString("yyyy-MM-dd")}', " +
                        $"email='{user.Email}', " +
                        $"experience='{user.Experience}', " +
                        $"is_active={user.IsActive}, " +
                        $"group_id={IsNull(user.GroupId)} " +
                      $"WHERE user_id = {user.UserId}";

            db.conn.Execute(sql);
        }
    }
}
