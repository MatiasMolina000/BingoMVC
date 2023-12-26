using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Services.Connection;

namespace APIBingo.Rules
{
    public class UserRule
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public UserRule(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<string?> New(UserRequest oModel)
        {
            var exist = await new UserData(_connectionFactory).CheckByUserOrEmail(oModel);
            if (exist) return "The user or email already exist.";


            Random rnd = new();
            int rndNum = rnd.Next(1000,1000000);

            var oUser = new UserModel() {
                User = oModel.User,
                Email = oModel.Email,
                Password = oModel.Password,
                PassTemp = rndNum.ToString(),
            };
            var add = await new UserData(_connectionFactory).New(oUser);
            if (add != null) return add;

            return null;
        }
    }
}
