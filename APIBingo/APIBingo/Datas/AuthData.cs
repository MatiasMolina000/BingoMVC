using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Services.Connection;
using System.Data;
using Dapper;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class AuthData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public AuthData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<UserModel?> Authentication(AuthRequest oModel)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) WHERE Email = @Email AND Password = @Password";
            UserModel? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetSingleObjectAsync<UserModel?>(query, oModel);
            return data;
        }
    }
}
