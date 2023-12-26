using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Services;
using APIBingo.Services.Connection;

namespace APIBingo.Datas
{
    public class UserData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public UserData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<bool> CheckByUserOrEmail(UserRequest oModel)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) WHERE Email = @Email AND Password = @Password";
            UserRequest? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetSingleObjectAsync<UserRequest?>(query, oModel);
            if (data != null) return true;
            return false;
        }
        public async Task<string?> New(UserModel oModel) 
        {
            string query = "INSERT INTO Users ([User], Email, [Password], PassTemp) VALUES (@User, @Email, @Password, @PassTemp)";
            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleStringAsync(query, oModel);
            if (data == null || data == "0")
                return "An error ocurred while saving the user";
            return null;
        }

    }
}
