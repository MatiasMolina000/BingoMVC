namespace APIBingo.Models
{
    public class BingoCageModel
    {
        private static readonly int s_MinNumber = 1;
        private static readonly int s_MaxNumber = 91;

        public long Id { get; set; }
        public int GameId { get; set; }
        public int Number { get; set; }
        public DateTime Created { get; set; }


        public BingoCageModel() { }


        public void CreateNewBall(GameModel oGame)
        {
            Random randomNumber = new();
            GameId = oGame.Id;
            Number = randomNumber.Next(s_MinNumber, s_MaxNumber);
            Created = DateTime.Now;
        }
    }
}
