using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Services.Connection;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace APIBingo.Datas
{
    public class AuthData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public AuthData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<UserModel?> Authentication(UserRequest oModel)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) WHERE Email = @Email AND Password = @Password";
            using IDbConnection cnn = _connectionFactory.CreateConnection();
            //using var cnn = new SqlConnection("Server=(local)\\SQLEXPRESS;Database=BingoGame;Trusted_Connection=True;MultipleActiveResultSets=true");
            try
            {
                var data = await cnn.QueryFirstOrDefaultAsync<UserModel>(query, oModel);
                cnn.Close();
                return data;
            }
            catch (Exception)
            {
                cnn.Close();
                return default;
            }
        }
    }
}
