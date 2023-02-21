namespace JuegoBingoAPI.Models
{
    public class BolilleroModel
    {
        public int ID { get; set; }
        public int Numeros { get; set; }
        public DateTime Alta{ get; set; }
        public int JuegoHistorialId{ get; set; }

        //public List<BolillaModel>? Bolillas { get; set; }

        public BolilleroModel LanzarBolilla(BolilleroModel bolillasJugadas)
        {
            BolillaModel bolilla = new();
            bolilla.BolillaAleatorea();

            return bolillasJugadas;
        }
    }
}
