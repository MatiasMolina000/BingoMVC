using APIBingo.Models;
using APIBingo.Services.Connection;
using APIBingo.Services;
namespace APIBingo.Datas
{
    public class BingoCardData
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public BingoCardData(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<List<BingoCardModel>> GetListByGameId(int gameId)
        {
            var query = "SELECT * FROM BingoCards WITH(NOLOCK) " +
                "WHERE GameId = @gameId;";

            IEnumerable<BingoCardModel> data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteGetListObjectAsync<BingoCardModel>(query, new { gameId });

            return data.ToList();
        }

        public async Task<string?> MatchNumberCalled(int gameId, int numberBall)
        {
            var query = "UPDATE BingoCardNumbers SET Called = 1 " +
                "FROM BingoCardNumbers bcn " +
                "INNER JOIN BingoCards bc ON bcn.BingoCardId = bc.Id " +
                "WHERE bc.GameId = @gameId AND bcn.Number = @numberBall; ";

            string? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteInsertSingleStringAsync(query, new { gameId, numberBall });

            if (data == null || data == "0")
            {
                return null;
            }

            return data;
        }

        public async Task<string?> FinishTheGameCard(List<BingoCardModel> oModelList)
        {
            var concatenatedNumbers = "";
            foreach (BingoCardModel oBingoCardModel in oModelList) 
            {
                concatenatedNumbers += $"{oBingoCardModel.Id}, ";
            }

            concatenatedNumbers = concatenatedNumbers[..^2];
            var query = $"UPDATE BingoCards SET Completed = 1 WHERE Id IN ({concatenatedNumbers});";

            string? data = await new DBFactoryConnectionService(_connectionFactory)
                .ExecuteInsertSingleStringAsync(query, null);

            if (data == null || data == "0")
            { 
                return null;
            }
            
            return data;
        }
    }
}
