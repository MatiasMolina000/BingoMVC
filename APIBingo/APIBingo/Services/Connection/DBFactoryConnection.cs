using System.Data.SqlClient;
using System.Data;

namespace APIBingo.Services.Connection
{
    public class DBFactoryConnection : IDBFactoryConnection
    {
        private readonly string _connectionString = string.Empty;


        public DBFactoryConnection(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("SQLServer");


        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
