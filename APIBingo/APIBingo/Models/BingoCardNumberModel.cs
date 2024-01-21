namespace APIBingo.Models
{
    public class BingoCardNumberModel
    {
        public int Id { get; set; }
        public int BingoCardId { get; set; }
        public int Number { get; set; }
        public bool Called { get; set; }

        public BingoCardNumberModel() { }
    }
}
