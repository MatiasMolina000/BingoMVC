namespace APIBingo.Models
{
    public class GameModel
    {
        private readonly int _numbersOfBingoCards = 4;


        public int Id { get; set; }
        public int UserId { get; set; }
        public short StatusId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public short Status { get; set; }

        public UserModel OUser { get; set; }
        public List<BingoCageModel> OBingoCages { get; set; }
        public List<BingoCardModel> OBingoCards { get; set; }

        
        public GameModel() { }

        public GameModel(UserModel oUserModel)
        {
            UserId = oUserModel.Id;
            StatusId = 1;
            Start = DateTime.Now;
            Status = 0;
            
            OUser = oUserModel;
            OBingoCages = new List<BingoCageModel>();

            CreateBingoCards();
        }


        public void DropNewBall()
        {
            BingoCageModel oBingoCage = new();
            if (OBingoCages == null || !OBingoCages.Any())
            {
                oBingoCage.CreateNewBall(this);
            }
            else
            {
                while (true)
                {
                    oBingoCage.CreateNewBall(this);
                    if (!OBingoCages.Any(item => item.Number == oBingoCage.Number))
                        break;
                }
            }
            OBingoCages.Add(oBingoCage);
        }

        private void CreateBingoCards() 
        {
            OBingoCards = new List<BingoCardModel>();
            for (int i = 1; i <= _numbersOfBingoCards; i++)
            {
                BingoCardModel bingoCard = new(i);
                IEnumerable<BingoCardModel> idemQuery =
                    from bCards in OBingoCards
                    where bCards.Numbers == bingoCard.Numbers
                    select bCards;

                if (idemQuery.Any())
                    bingoCard.RedefineNumbers();

                OBingoCards.Add(bingoCard);
            };
        }
    }
}
