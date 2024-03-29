﻿using Dapper;
using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    // Modtager kald fra controlleren, sender queries til databasen og returnerer resultatet
    public class TeamRepository : ITeamRepository
    {
        DBContext db;

        public TeamRepository(DBContext context)
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

        public IEnumerable<User> GetTeamMembers(int teamid)
        {
            var sql = $"SELECT * " +
                      $"FROM users " +
                      $"WHERE team_id={teamid};";

            return db.conn.Query<User>(sql);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            var sql = "SELECT * " +
                      "FROM team";

            return db.conn.Query<Team>(sql);
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
            var sql = $"INSERT INTO team(team_id, name) " +
                      $"VALUES (DEFAULT, '{team.Name}')";

            db.conn.Execute(sql);
        }
        public void DeleteTeam(int teamid)
        {
            var sql = $"DELETE FROM team " +
                      $"WHERE team_id={teamid}";

            db.conn.Execute(sql);
        }

        // Edit team
        public void PutTeam(Team team)
        {
            var sql = $"UPDATE team " +
                      $"SET " +
                        $"name={team.Name} " +
                      $"WHERE team_id={team.TeamId}";

            db.conn.Execute(sql);
        }
    }
}
