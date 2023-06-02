using Npgsql;
using System.Data;

namespace Infrastructure.DataAccess
{
    public class DbConnector
    {
        public IDbConnection CreateConnection() => new NpgsqlConnection(Environment.GetEnvironmentVariable("DBCONN"));
    }
}
