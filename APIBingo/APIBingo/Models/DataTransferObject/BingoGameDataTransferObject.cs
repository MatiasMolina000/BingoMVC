namespace APIBingo.Models.DataTransferObject
{
    public class BingoGameDataTransferObject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public short StatusId { get; set; }
        public List<BingoCageDataTransferObject> OBingoCagesDataTransferObject { get; set; }
        public List<BingoCardDataTransferObject> OBingoCardsDataTransferObject { get; set; }

        public BingoGameDataTransferObject(GameModel oGameModel)
        {
            Id = oGameModel.Id;
            UserId = oGameModel.UserId;
            StatusId = oGameModel.StatusId;
            OBingoCagesDataTransferObject = new List<BingoCageDataTransferObject>();
            OBingoCardsDataTransferObject = new List<BingoCardDataTransferObject>();
        }

        public void FillListBingoCages(List<BingoCageModel> listOBingoCageModel)
        {
            OBingoCagesDataTransferObject = listOBingoCageModel
                .Select(oBingoCageModel => new BingoCageDataTransferObject 
                { 
                    Number = oBingoCageModel.Number,
                    Created = oBingoCageModel.Created
                }).ToList();
        }

        public void FillListBingoCards(List<BingoCardModel> listOBingoCardModel)
        {
            OBingoCardsDataTransferObject = listOBingoCardModel
                .Select(oBingoCardModel => new BingoCardDataTransferObject
                {
                    Card = oBingoCardModel.Card,
                    OrderedN = oBingoCardModel.OrderedN,
                    Completed = oBingoCardModel.Completed
                }).ToList();
        }
    }
}
