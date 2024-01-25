namespace APIBingo.Models.DataTransferObject
{
    public class BingoCageDataTransferObject
    {
        public int Number { get; set; }
        public DateTime Created { get; set; }

        public void FillDTOFromModel(BingoCageModel oBingoCageModel) 
        {
            Number = oBingoCageModel.Number;
            Created = oBingoCageModel.Created;
        }
    }
}
