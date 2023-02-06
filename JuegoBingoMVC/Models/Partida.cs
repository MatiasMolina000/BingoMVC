namespace JuegoBingoMVC.Models
{
    public class Partida
    {
        public int Id { get; set; }
        public List<Carton>? Jugadores { get; set; }
        public Bolillero Bolillero { get; set; }

        public Partida(int nCartones)
        {
            try
            {
                //Armo los cartones vacíos para el juego
                Carton cartones = new();
                Jugadores = cartones.ArmarJego(nCartones);

                //Obtengo listado de números
                Bolillero bilillero = new();
                Bolillero = bilillero;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
