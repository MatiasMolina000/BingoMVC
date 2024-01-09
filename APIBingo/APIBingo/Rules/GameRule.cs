using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Response;
using APIBingo.Services.Connection;

namespace APIBingo.Rules
{
    public class GameRule
    {
        private readonly IDBFactoryConnection _connectionFactory;

        public GameRule(IDBFactoryConnection connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<ResultResponse<GameModel>> New(int userId) 
        {
            ResultResponse<GameModel> response = new();

            UserModel? oUser = await new UserData(_connectionFactory).GetById(userId.ToString());

            if (oUser == null)
            {
                response.Message = "Unauthorized.";
                response.Success = false;
            }
            else 
            { 
                GameModel game = new(oUser);
                response.Data = game;
            }
            return response;
        }
    }
}
