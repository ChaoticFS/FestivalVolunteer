using Npgsql;

namespace FestivalVolunteer.Server.Models
{
    public class DBContext
    {
        public readonly NpgsqlConnection conn;
        public DBContext()
        {
            string connString = "User ID=starfest;Password={password};Host=starfest.postgres.database.azure.com;Port=5432;Database=starfest";
            conn = new NpgsqlConnection(connString);
        }
    }
}
