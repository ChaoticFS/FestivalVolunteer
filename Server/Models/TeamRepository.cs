using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public class TeamRepository : ITeamRepository
    {
        DBContext db;

        public TeamRepository()
        {
            this.db = new DBContext();
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IEnumerable<User> GetTeamMembers(int teamid)
        {
            var sql = $"SELECT user_id, role_id, team_id, name, birthday, email, experience, is_active, group_id" +
                      $"FROM users" +
                      $"WHERE team_id = @teamid";

            return db.conn.Query<User>(sql);
        }
        public Team GetTeam(int teamid)
        {
            var sql = $"SELECT name " +
                      $"FROM team " +
                      $"WHERE team_id={teamid}";

            return db.conn.Query<Team>(sql).First();
        }
        public void PostTeam(Team team)
        {
            var sql = $"INSERT INTO team (name)" +
                      $"VALUES (@Name)";

            db.conn.Execute(sql);
        }
        public void DeleteTeam(int teamid)
        {
            var sql = $"DELETE FROM team" +
                      $"WHERE team_id={teamid}";

            db.conn.Execute(sql);
        }
        public void PutTeam(Team team)
        {
            var sql = $"UPDATE team" +
                      $"SET " +
                        $"name = @Name" +
                      $"WHERE team_id = @TeamId";

            db.conn.Execute(sql);
        }
    }
}
