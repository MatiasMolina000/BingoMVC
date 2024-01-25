using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class GameData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public GameData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<GameModel?> GetById(int id)
        {
            var query = "SELECT * FROM Games WITH(NOLOCK) WHERE Id = @id;";

            GameModel? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetSingleObjectAsync<GameModel>(query, new { id });
            return data;
        }

        public async Task<string?> NewGame(GameModel oModel)
        {
            var query = "INSERT INTO Games " +
                        "(UserId, StatusId, Start, Status) " +
                        "VALUES (@UserId, @StatusId, @Start, @Status); " +
                        "SELECT SCOPE_IDENTITY();";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleAndGetIdAsync(query, oModel);
            if (data == null || data == "0")
                return null;
            return data;
        }

        public async Task<string?> NewGameBingoCards(List<BingoCardModel> listOModel)
        {
            var query = "INSERT INTO BingoCards " +
                           "(GameId, [Card], Numbers, OrderedN, Completed) " +
                           "VALUES ";
            foreach (BingoCardModel iModel in listOModel)
            { 
                query += $"({iModel.GameId}, {iModel.Card}, '{iModel.Numbers}', '{iModel.OrderedN}', 0), ";
            }
            query = query[..^2] + ";";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleStringAsync(query, null);
            if (data == null || data == "0")
                return null;
            return data;
        }

        public async Task<string?> NewGameBingoCardNumbers(List<BingoCardModel> listOBingoCards)
        {
            var query = "INSERT INTO BingoCardNumbers " +
                           "(BingoCardId, Number, Called) " +
                           "VALUES ";
            foreach (BingoCardModel oBingoCard in listOBingoCards)
            {
                foreach (BingoCardNumberModel oBingoCardNumber in oBingoCard.OBingoCardNumbers)
                {
                    query += $"({oBingoCard.Id}, {oBingoCardNumber.Number}, 0), ";
                }
            }
            query = query[..^2] + ";";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleStringAsync(query, null);
            if (data == null || data == "0")
                return null;
            return data;
        }

        public async Task<string?> FinishTheGame(int gameId)
        {
            var query = "UPDATE Games SET StatusId = 2, [End] = GETDATE(), [Status] = 1 WHERE Id = @gameId;";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleStringAsync(query, new { gameId });
            if (data == null || data == "0")
                return null;
            return data;
        }

        public async Task<GameModel?> GetActiveByUserId(int usreId)
        {
            var query = "SELECT * FROM Games WITH(NOLOCK) WHERE UserId = @usreId AND StatusId = 1 AND [Status] = 0;";

            GameModel? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetSingleObjectAsync<GameModel>(query, new { usreId });
            return data;
        }

        public async Task<string?> CloseTheGame(int gameId)
        {
            var query = "UPDATE Games SET StatusId = 3, [End] = GETDATE(), [Status] = 1 WHERE Id = @gameId;";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleStringAsync(query, new { gameId });
            if (data == null || data == "0")
                return null;
            return data;
        }
    }
}
