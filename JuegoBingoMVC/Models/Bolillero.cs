namespace JuegoBingoMVC.Models
{
    public class Bolillero
    {
        public List<Bolilla>? Bolillas { get; set; }

        public Bolillero() { }
        public Bolillero LanzarBolilla(Bolillero bolillasJugadas)
        {
            Bolilla bolilla = new();

            //bool yaJugada = bolillasJugadas.Bolillas.Find(bolilla);
            //for (int i = 0; i < cantidades; i++)
            //{ 
            //    var carton = new Carton();
            //    misCartones.Add(carton);
            //}
            return bolillasJugadas;
        }

        //public Bolillero LlenarBolillero()
        //{
        //    Bolillero bolillero = new();
        //    var numero = new Bolilla();
        //    bolillero.Bolillas = numero.Llenar();
        //    return bolillero;
        //}

    }
}
