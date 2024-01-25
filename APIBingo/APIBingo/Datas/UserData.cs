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


        public async Task<bool> CheckByUserOrEMail(UserRequest oModel)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) " +
                "WHERE Email = @Email AND Password = @Password";
            
            UserRequest? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteGetSingleObjectAsync<UserRequest?>(query, oModel);

            if (data != null) 
            { 
                return true;
            } 

            return false;
        }
        public async Task<string?> New(UserModel oModel) 
        {
            string query = "INSERT INTO Users ([User], Email, [Password], PassTemp) " +
                "VALUES (@User, @Email, @Password, @PassTemp)";

            string? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteInsertSingleStringAsync(query, oModel);

            if (data == null || data == "0")
            { 
                return "An error ocurred while saving the user";
            }
            
            return null;
        }

        public async Task<UserModel?> GetById(string id)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) " +
                "WHERE Id = @id;";
            
            UserModel? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteGetSingleObjectAsync<UserModel>(query, new { id });
            
            return data;
        }

        public async Task<string?> EMailValidator(UserModel oUser)
        {
            string query = "UPDATE Users " +
                "SET StatusId = 1, PassTemp = NULL " +
                "WHERE Id = @Id;";
            
            string? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteInsertSingleStringAsync(query, oUser);

            if (data == null || data == "0")
            { 
                return "An error ocurred while saving the user";
            }
            
            return null;
        }

        public async Task<bool> CheckUpdatesByUserOrEMail(UserModel oUser)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) " +
                "WHERE Id <> @Id AND ([User] = @User OR Email = @Email);";

            UserRequest? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteGetSingleObjectAsync<UserRequest?>(query, oUser);

            if (data != null)
            { 
                return true;
            }

            return false;
        }
        
        public async Task<string?> Update(UserModel oUser)
        {
            string query = "UPDATE Users " +
                "SET [User] = @User, Email = @Email, [Password] = @Password, " +
                "PassTemp = @PassTemp, StatusId = @StatusId WHERE Id = @Id;";
            
            string? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteInsertSingleStringAsync(query, oUser);

            if (data == null || data == "0")
            { 
                return "An error ocurred while saving the changes";
            }

            return null;
        }
    }
}
