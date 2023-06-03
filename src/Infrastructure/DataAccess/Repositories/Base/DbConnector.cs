using Npgsql;
using System.Data;

namespace Infrastructure.DataAccess.Repositories.Base
{
    public class DbConnector
    {
        public IDbConnection CreateConnection() => new NpgsqlConnection(Environment.GetEnvironmentVariable("DBCONN"));
    }
}
