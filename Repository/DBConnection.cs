using Microsoft.Data.SqlClient;
using System.Data;
using static MyWebApplication.Repository.DBConnection;

namespace MyWebApplication.Repository
{
    public class DBConnection: IDatabaseConnection
    {
        private readonly IConfiguration _configuration;
        public DBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public interface IDatabaseConnection
        {
            IDbConnection GetConnection();
        }
    }
}
