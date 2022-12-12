using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public class TeamRepository : ITeamRepository
    {
        DBContext db = new DBContext();
        public List<User> GetTeamMembers(int teamid)
        {
            throw new NotImplementedException();
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
                      $"VALUES ('{team.Name}')";

            db.conn.Query(sql);
        }
        public void DeleteTeam(int teamid)
        {
            throw new NotImplementedException();
        }
        public void PutTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
