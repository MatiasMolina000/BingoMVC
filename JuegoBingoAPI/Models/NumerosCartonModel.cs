using System.Security.Cryptography.Xml;

namespace JuegoBingoAPI.Models
{
    public class NumerosCartonModel
    {
        public int ID { get; set; }
        public int CartonId { get; set; }
        public int Numero { get; set; }
        public bool Estado { get=> false; }

    }
}
