namespace APIBingo.Models.DataTransferObject
{
    public class BingoCardDataTransferObject
    {
        public int Card { get; set; }
        public string? OrderedN { get; set; }
        public bool Completed { get; set; }
    }
}
