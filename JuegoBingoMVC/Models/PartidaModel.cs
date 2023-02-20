namespace JuegoBingoMVC.Models
{
    public class PartidaModel
    {
        public int Id { get; set; }
        public List<CartonModel>? Jugadores { get; set; }
        public BolilleroModel Bolillero { get; set; }

        public PartidaModel(int nCartones)
        {
            try
            {
                //Armo los cartones vacíos para el juego
                CartonModel cartones = new();
                Jugadores = cartones.ArmarJego(nCartones);

                //Obtengo listado de números
                BolilleroModel bilillero = new();
                Bolillero = bilillero;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
