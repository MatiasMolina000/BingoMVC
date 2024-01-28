using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;

namespace APIBingo.Datas
{
    public class BingoCardNumberData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public BingoCardNumberData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<List<BingoCardNumberModel>> GetListByBingoCardId(BingoCardModel oModel)
        {
            var query = "SELECT * FROM BingoCardNumbers WITH(NOLOCK) " +
                "WHERE BingoCardId = @Id;";

            IEnumerable<BingoCardNumberModel> data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteGetListObjectAsync<BingoCardNumberModel>(query, oModel);
            
            return data.ToList();
        }
    }
}
