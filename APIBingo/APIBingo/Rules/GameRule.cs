using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Response;
using APIBingo.Services.Connection;

namespace APIBingo.Rules
{
    public class GameRule
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public GameRule(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<ResultResponse<GameModel>> New(int userId) 
        {
            ResultResponse<GameModel> response = new();

            UserModel? oUser = await new UserData(_connectionFactory).GetById(userId.ToString());
            if (oUser == null)
            {
                response.Message = "Unauthorized.";
                return response;
            }

            GameModel oGame = new(oUser);
            string? data = await new GameData(_connectionFactory).NewGame(oGame);
            if (data == null)
            {
                response.Message = "An error ocurred while saving game.";
                return response;
            }
            oGame.Id = int.Parse(data);
            
            oGame.OBingoCards.ForEach(iBingoCard => iBingoCard.GameId = oGame.Id);
            data = await new GameData(_connectionFactory).NewGameBingoCards(oGame.OBingoCards);
            if (data == null)
            {
                response.Message = "An error ocurred while saving the bingo cards.";
                return response;
            }

            List<BingoCardModel> listOBingoCards = await new BingoCardData(_connectionFactory).GetListByGameId(oGame);
            foreach (var bingoCard in oGame.OBingoCards)
            {
                var matchBingoCard = listOBingoCards.FirstOrDefault(bingoCardOfList => bingoCardOfList.Card == bingoCard.Card);
                if (matchBingoCard != null)
                    bingoCard.Id = matchBingoCard.Id;
            }
            data = await new GameData(_connectionFactory).NewGameBingoCardNumbers(oGame.OBingoCards);
            if (data == null)
            {
                response.Message = "An error ocurred while saving the bingo cards.";
                return response;
            }

            response.Success = true;
            response.Data = oGame;
            return response;
        }
    }
}
