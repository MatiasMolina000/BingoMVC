using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class GameData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public GameData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


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
    }
}
