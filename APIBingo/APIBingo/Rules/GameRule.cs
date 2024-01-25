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

        public async Task<ResultResponse<BingoCageModel>> DropBall(int userId, int gameId)
        {
            ResultResponse<BingoCageModel> response = new();

            GameModel? oGame = await new GameData(_connectionFactory).GetById(gameId);
            if (oGame == null)
            {
                response.Message = "The game does not exist.";
                return response;
            }
            if (oGame.UserId != userId)
            {
                response.Message = "Invalid data.";
                return response;
            }
            if (oGame.StatusId != 0)
            {
                response.Message = "The game is not available.";
                return response;
            }

            List<BingoCageModel>? oBingoCage = await new BingoCageData(_connectionFactory).GetListByGameId(oGame);
            oGame.OBingoCages = oBingoCage ?? new List<BingoCageModel>();
            List<BingoCardModel> oBingoCards = await new BingoCardData(_connectionFactory).GetListByGameId(oGame);
            oGame.OBingoCards = oBingoCards ?? new List<BingoCardModel>();
            foreach (BingoCardModel bingoCardModel in oGame.OBingoCards)
            {
                List<BingoCardNumberModel> oBingoCardNumber = await new BingoCardNumberData(_connectionFactory).GetListByBingoCardId(bingoCardModel);
                bingoCardModel.OBingoCardNumbers = oBingoCardNumber;
            }

            oGame.DropNewBall();
            BingoCageModel oBall = oGame.OBingoCages[^1];
            string? ballId = await new BingoCageData(_connectionFactory).NewBingoCage(oBall);
            if (string.IsNullOrEmpty(ballId))
            {
                response.Message = "An error ocurred while saving the bingo ball.";
                return response;
            }

            var matchNumberCalled = false;
            foreach (BingoCardModel bingoCardModel in oGame.OBingoCards) 
            {
                if (bingoCardModel.OBingoCardNumbers.FirstOrDefault(bingoCardNumber => bingoCardNumber.Number == oBall.Number) != null)
                {
                    matchNumberCalled = true;
                    break;
                }
            }
            string? matchCardNumbers = null;
            if (matchNumberCalled) 
            {
                oGame.OBingoCards.ForEach(oBingoCard =>
                {
                    oBingoCard.OBingoCardNumbers
                        .Where(oBingoCardNumber => oBingoCardNumber.Number == oBall.Number)
                        .ToList()
                        .ForEach(oBingoCardNumber => oBingoCardNumber.Called = true);
                });
                    
                matchCardNumbers = await new BingoCardData(_connectionFactory).MatchNumberCalled(oGame.Id, oBall.Number);
                if (string.IsNullOrEmpty(matchCardNumbers))
                {
                    response.Message = "An error ocurred while saving the bingo ball in cards.";
                    return response;
                }
            }

            oBall.Id = int.Parse(ballId);

            if (oGame.OBingoCages.Count > 14)
            {
                var winners = new List<BingoCardModel>();
                foreach (BingoCardModel bingoCard in oGame.OBingoCards) 
                {
                    var matchs = 0;
                    matchs = bingoCard.OBingoCardNumbers.Count(bingoCardNumber => bingoCardNumber.Called == true);
                    if (matchs == 15) 
                    {
                        BingoCardModel winner = oGame.OBingoCards.First(winnerBingoCard => winnerBingoCard.Id == bingoCard.Id);
                        winners.Add(winner);
                    }
                }
                if (winners.Any()) 
                {
                    string? data = await new GameData(_connectionFactory).FinishTheGame(oGame.Id);
                    data = await new BingoCardData(_connectionFactory).FinishTheGameCard(winners);
                    if (data == null)
                    {
                        response.Message = "An error ocurred while saving the bingo cards.";
                        return response;
                    }

                    response.Message = $"Bingo card winner: N° {winners[0].Card}.";
                    if (winners.Count > 1)
                    {
                        var concatenatedNumbers = "";
                        foreach (BingoCardModel oBingoCardModel in winners)
                        {
                            concatenatedNumbers += $" N° {oBingoCardModel.Card}, ";
                        }
                        concatenatedNumbers = concatenatedNumbers[..^2];
                        response.Message = $"Bingo cards winners: {concatenatedNumbers}.";
                    }
                    response.Data = oBall;
                    response.Success = true;
                    return response;
                }
            }

            response.Message = $"Called ball: {oBall.Number}";
            response.Data = oBall;
            response.Success = true;
            return response;
        }

        public async Task<ResultResponse<GameModel>> Load(int userId) 
        {
            ResultResponse<GameModel> response = new();

            UserModel? oUser = await new UserData(_connectionFactory).GetById(userId.ToString());
            if (oUser == null)
            {
                response.Message = "Unauthorized.";
                return response;
            }

            GameModel? oGame = await new GameData(_connectionFactory).GetActiveByUserId(userId);
            if (oGame == null)
            {
                response.Message = "There is no game to load.";
                return response;
            }

            oGame.OUser = oUser;

            List<BingoCageModel>? oBingoCage = await new BingoCageData(_connectionFactory).GetListByGameId(oGame);
            oGame.OBingoCages = oBingoCage ?? new List<BingoCageModel>();
            List<BingoCardModel> oBingoCards = await new BingoCardData(_connectionFactory).GetListByGameId(oGame);
            oGame.OBingoCards = oBingoCards ?? new List<BingoCardModel>();
            foreach (BingoCardModel bingoCardModel in oGame.OBingoCards)
            {
                List<BingoCardNumberModel> oBingoCardNumber = await new BingoCardNumberData(_connectionFactory).GetListByBingoCardId(bingoCardModel);
                bingoCardModel.OBingoCardNumbers = oBingoCardNumber;
            }

            response.Success = true;
            response.Data = oGame;
            return response;
        }

        public async Task<ResultResponse<GameModel>> Close(int userId)
        {
            ResultResponse<GameModel> response = new();

            UserModel? oUser = await new UserData(_connectionFactory).GetById(userId.ToString());
            if (oUser == null)
            {
                response.Message = "Unauthorized.";
                return response;
            }

            GameModel? oGame = await new GameData(_connectionFactory).GetActiveByUserId(userId);
            if (oGame == null)
            {
                response.Message = "There is no game to close.";
                return response;
            }

            string? data = await new GameData(_connectionFactory).CloseTheGame(oGame.Id);
            if (data == null)
            {
                response.Message = "An error ocurred while closed the bingo game.";
                return response;
            }

            response.Message = "Now, there is no game to load.";
            response.Success = true;
            response.Data = null;
            return response;
        }
    }
}
