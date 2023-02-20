using JuegoBingoAPI.Models;

namespace JuegoBingoAPI.Models
{
    public class PartidaModel
    {
        private int _estado_Id = 1;
        private string _usuarioId = string.Empty;

        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int? Carton1 { get; set; }
        public int? Carton2 { get; set; }
        public int? Carton3 { get; set; }
        public int? Carton4 { get; set; }
        public int EstadoId { get => _estado_Id; set => _estado_Id = value; }
        public string UsuarioId { get => _usuarioId; set => _usuarioId = value; }

        //public List<CartonModel>? Cartones { get; set; }
        //public BolilleroModel Bolillero { get; set; }


        /*public PartidaModel(string usuario, int nCartones)
        {
            try
            {
                Usuario_Id = usuario;

                //Armo los cartones vacíos para el juego
                CartonModel cartones = new();
                Cartones = cartones.ArmarJego(nCartones);

                //Obtengo listado de números
                //BolilleroModel bilillero = new();
                //Bolillero = bilillero;
            }
            catch (Exception)
            {

                throw;
            }
            

        }*/
    }
}
