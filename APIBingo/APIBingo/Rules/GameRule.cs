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
            }
            else 
            { 
                GameModel game = new(oUser);
                string? data = await new GameData(_connectionFactory).NewGame(game);
                if (data == null)
                {
                    response.Message = "An error ocurred while saving game.";
                }
                else 
                {
                    game.Id = int.Parse(data);
                    game.OBingoCards.ForEach(iBingoCard => iBingoCard.GameId = game.Id);

                    data = await new GameData(_connectionFactory).NewGameBingoCards(game.OBingoCards);
                    if (data == null)
                    {
                        response.Message = "An error ocurred while saving the bingo cards.";
                    }
                    else 
                    {
                        response.Success = true;
                        response.Data = game;
                    }
                }
            }
            return response;
        }
    }
}
