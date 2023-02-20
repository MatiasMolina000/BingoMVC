namespace JuegoBingoMVC.Models
{
    public class BolilleroModel
    {
        public List<BolillaModel>? Bolillas { get; set; }

        public BolilleroModel() { }
        public BolilleroModel LanzarBolilla(BolilleroModel bolillasJugadas)
        {
            BolillaModel bolilla = new();

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
