using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class BingoCageData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public BingoCageData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<List<BingoCageModel>?> GetListByGameId(int gameId)
        {
            var query = "SELECT * FROM BingoCages WITH(NOLOCK) WHERE GameId = @gameId;";

            IEnumerable<BingoCageModel> data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetListObjectAsync<BingoCageModel>(query, new { gameId });
            return data.ToList();
        }

        public async Task<string?> NewBingoCage(BingoCageModel oModel)
        {
            var query = "INSERT INTO BingoCages " +
                           "(GameId, Number, Created) " +
                           "VALUES (@GameId, @Number, @Created); " +
                           "SELECT SCOPE_IDENTITY();";

            string? data = await new DBFactoryConnectionService(_connectionFactory).ExecuteInsertSingleAndGetIdAsync(query, oModel);
            if (data == null || data == "0")
                return null;
            return data;
        }
    }
}
