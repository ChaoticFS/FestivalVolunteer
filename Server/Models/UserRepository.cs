using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public class UserRepository : IUserRepository
    {
        DBContext db;

        public UserRepository()
        {
            this.db = new DBContext();
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public User GetUser(int userid)
        {
            var sql = $"SELECT * " +
                      $"FROM users " +
                      $"WHERE user_id={userid}";

            return db.conn.Query<User>(sql).First();
        }
        public void PostUser(User user)
        {
            throw new NotImplementedException();
        }
        public void PutUser(User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
