using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.DataTransferObject;
using APIBingo.Models.Response;
using APIBingo.Services.Connection;

namespace APIBingo.Rules
{
    public class GameRule
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public GameRule(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<ResultResponse<BingoGameDataTransferObject>> New(int userId)
        {
            ResultResponse<BingoGameDataTransferObject> response = new();

            // User existence and active status check.
            string? checkUserById = await CheckUserById(userId);

            if (!string.IsNullOrEmpty(checkUserById))
            {
                response.Message = checkUserById;
                return response;
            }

            // Game existence.
            GameModel? oGame = await new GameData(_connectionFactory)
                .GetActiveByUserId(userId);

            if (oGame != null)
            {
                response.Message = "There is a pending game.";
                return response;
            }

            // Build Game

            //// Build and save the Game Entity
            oGame = new(userId);

            string? data = await new GameData(_connectionFactory)
                .NewGame(oGame);

            if (data == null)
            {
                response.Message = "An error ocurred while saving game.";
                return response;
            }

            //// Build and save the BingoCards Entities
            oGame.Id = int.Parse(data);

            oGame.OBingoCards.ForEach(iBingoCard => iBingoCard.GameId = oGame.Id);

            data = await new GameData(_connectionFactory)
                .NewGameBingoCards(oGame.OBingoCards);

            if (data == null)
            {
                response.Message = "An error ocurred while saving the bingo cards.";
                return response;
            }

            //// Build and save the BingoCardNumbers Entities
            List<BingoCardModel> listOBingoCards = await new BingoCardData(_connectionFactory)
                .GetListByGameId(oGame.Id);

            foreach (var bingoCard in oGame.OBingoCards)
            {
                var matchBingoCard = listOBingoCards
                    .FirstOrDefault(bingoCardOfList => bingoCardOfList.Card == bingoCard.Card);

                if (matchBingoCard != null) 
                { 
                    bingoCard.Id = matchBingoCard.Id;
                }
            }

            data = await new GameData(_connectionFactory)
                .NewGameBingoCardNumbers(oGame.OBingoCards);
            if (data == null)
            {
                response.Message = "An error ocurred while saving the bingo cards.";
                return response;
            }

            // Build BingoGameDTO to response.
            BingoGameDataTransferObject oBingoGameDTO = await BuildBingoGameDTO(oGame);

            // Return successful response.
            response.Success = true;
            response.Data = oBingoGameDTO;
            return response;
        }

        public async Task<ResultResponse<BingoCageDataTransferObject>> DropBall(int userId, int gameId)
        {
            ResultResponse<BingoCageDataTransferObject> response = new();

            // User existence and active status check.
            string? checkUserById = await CheckUserById(userId);
            if (!string.IsNullOrEmpty(checkUserById))
            {
                response.Message = checkUserById;
                return response;
            }

            // Game existence.
            GameModel? oGame = await new GameData(_connectionFactory)
                .GetById(gameId);

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
            if (oGame.StatusId != 1)
            {
                response.Message = "The game is not available.";
                return response;
            }

            //// Fill the list of the BingoCage Entities and add it into the oGameModel
            List<BingoCageModel>? oBingoCage = await new BingoCageData(_connectionFactory)
                .GetListByGameId(oGame.Id);
            oGame.OBingoCages = oBingoCage ?? new List<BingoCageModel>();

            //// Fill the list of the BingoCard Entities and add it into the oGameModel
            List<BingoCardModel> oBingoCards = await new BingoCardData(_connectionFactory)
                .GetListByGameId(oGame.Id);
            oGame.OBingoCards = oBingoCards ?? new List<BingoCardModel>();

            //// Fill the list of the BingoCardNumbers Entities and add it into the oGameModel.BingoCardNumberModel
            foreach (BingoCardModel bingoCardModel in oGame.OBingoCards)
            {
                List<BingoCardNumberModel> oBingoCardNumber = await new BingoCardNumberData(_connectionFactory)
                    .GetListByBingoCardId(bingoCardModel);
                bingoCardModel.OBingoCardNumbers = oBingoCardNumber;
            }

            // Funcionality that creates a new ball, seves the new record and creates the BingoCageModel object.
            oGame.DropNewBall();

            BingoCageModel oBall = oGame.OBingoCages[^1];

            string? ballId = await new BingoCageData(_connectionFactory)
                .NewBingoCage(oBall);
            
            if (string.IsNullOrEmpty(ballId))
            {
                response.Message = "An error ocurred while saving the bingo ball.";
                return response;
            }

            // Matching control with bingo cards and saves the changes. 
            var matchNumberCalled = false;
            foreach (BingoCardModel bingoCardModel in oGame.OBingoCards)
            {
                if (bingoCardModel.OBingoCardNumbers
                    .FirstOrDefault(bingoCardNumber => bingoCardNumber.Number == oBall.Number) != null)
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

                matchCardNumbers = await new BingoCardData(_connectionFactory)
                    .MatchNumberCalled(oGame.Id, oBall.Number);

                if (string.IsNullOrEmpty(matchCardNumbers))
                {
                    response.Message = "An error ocurred while saving the bingo ball in cards.";
                    return response;
                }
            }

            oBall.Id = int.Parse(ballId);

            // Build BingoCageDTO to response.
            var oBingoCageDTO = new BingoCageDataTransferObject();
            oBingoCageDTO.FillDTOFromModel(oBall);

            // Winners control.
            if (oGame.OBingoCages.Count > 14)
            {
                var winners = new List<BingoCardModel>();

                // Count and search for 15 matches.
                foreach (BingoCardModel bingoCard in oGame.OBingoCards)
                {
                    var matchs = 0;
                    matchs = bingoCard.OBingoCardNumbers
                        .Count(bingoCardNumber => bingoCardNumber.Called == true);

                    if (matchs == 15)
                    {
                        BingoCardModel winner = oGame.OBingoCards
                            .First(winnerBingoCard => winnerBingoCard.Id == bingoCard.Id);

                        winners.Add(winner);
                    }
                }

                // Finishes the game if exist winners
                if (winners.Any())
                {
                    string? data = await new GameData(_connectionFactory)
                        .FinishTheGame(oGame.Id);

                    data = await new BingoCardData(_connectionFactory)
                        .FinishTheGameCard(winners);

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

                    // Return successful response.
                    response.Data = oBingoCageDTO;
                    response.Success = true;
                    return response;
                }
            }

            // Return successful response.
            response.Message = $"Called ball: {oBingoCageDTO.Number}";
            response.Data = oBingoCageDTO;
            response.Success = true;
            return response;
        }

        public async Task<ResultResponse<BingoGameDataTransferObject>> Load(int userId)
        {
            ResultResponse<BingoGameDataTransferObject> response = new();

            // User existence and active status check.
            string? checkUserById = await CheckUserById(userId);
            if (!string.IsNullOrEmpty(checkUserById))
            {
                response.Message = checkUserById;
                return response;
            }

            // Game existence.
            GameModel? oGame = await new GameData(_connectionFactory)
                .GetActiveByUserId(userId);

            if (oGame == null)
            {
                response.Message = "There is no game to load.";
                return response;
            }

            // Build BingoGameDTO to response.
            BingoGameDataTransferObject oBingoGameDTO = await BuildBingoGameDTO(oGame);

            // Return successful response.
            response.Success = true;
            response.Data = oBingoGameDTO;
            return response;
        }

        public async Task<ResultResponse<BingoGameDataTransferObject>> Close(int userId)
        {
            ResultResponse<BingoGameDataTransferObject> response = new()
            {
                Data = null
            };

            // User existence and active status check.
            string? checkUserById = await CheckUserById(userId);
            if (!string.IsNullOrEmpty(checkUserById))
            {
                response.Message = checkUserById;
                return response;
            }

            // Game existence.
            GameModel? oGame = await new GameData(_connectionFactory)
                .GetActiveByUserId(userId);

            if (oGame == null)
            {
                response.Message = "There is no game to close.";
                return response;
            }

            string? data = await new GameData(_connectionFactory)
                .CloseTheGame(oGame.Id);

            if (string.IsNullOrEmpty(data))
            {
                response.Message = "An error ocurred while closed the bingo game.";
                return response;
            }

            // Return successful response.
            response.Message = "Now, there is no game to load.";
            response.Success = true;
            return response;
        }


        private async Task<string?> CheckUserById(int userId)
        {
            UserModel? oUser = await new UserData(_connectionFactory).GetById(userId.ToString());
            if (oUser == null) 
            { 
                return "Invalid User Id.";
            }

            if (oUser.StatusId == 2)
            { 
                return "User not available.";
            }

            if (oUser.StatusId == 3)
            { 
                return "Email address pending validation.";
            }

            return null;
        }

        private async Task<BingoGameDataTransferObject> BuildBingoGameDTO(GameModel oGame)
        {
            var oBingoGameDTO = new BingoGameDataTransferObject(oGame);

            List<BingoCageModel>? oBingoCage = await new BingoCageData(_connectionFactory).GetListByGameId(oBingoGameDTO.Id);
            if (oBingoCage != null)
                oBingoGameDTO.FillListBingoCages(oBingoCage);

            List<BingoCardModel> oBingoCards = await new BingoCardData(_connectionFactory).GetListByGameId(oBingoGameDTO.Id);
            oBingoGameDTO.FillListBingoCards(oBingoCards);

            return oBingoGameDTO;
        }
    }
}
