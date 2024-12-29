using Microsoft.Data.SqlClient;
using System.Data;

namespace MyWebApplication.Repository
{
    public class DBConnection
    {
        private readonly IConfiguration _configuration;
        public DBConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            // 確保從 appsettings.json 或其他配置來源讀取資料庫連接字串
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}
