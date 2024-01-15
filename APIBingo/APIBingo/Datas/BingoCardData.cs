using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class BingoCardData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public BingoCardData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<List<BingoCardModel>> GetListByGameId(GameModel oModel)
        {
            var query = "SELECT * FROM BingoCards WITH(NOLOCK) WHERE GameId = @Id;";

            IEnumerable<BingoCardModel> data = await new DBFactoryConnectionService(_connectionFactory).ExecuteGetListObjectAsync<BingoCardModel>(query, oModel);
            return data.ToList();
        }
    }
}
