namespace JuegoBingoAPI.Models
{
    public class BolillaModel
    {
        private readonly int _valorMinimo = 1;
        private readonly int _valorMaximo = 90;
        private int _numeroBolilla;

        public int Minimo { get => _valorMinimo; }

        public int Maximo { get => _valorMaximo; }

        public string NumeroBolilla
        {
            get => _numeroBolilla.ToString();
            set => _numeroBolilla = Convert.ToInt32(value);
        }

        public BolillaModel() { }

        public BolillaModel BolillaAleatorea()
        {
            Random bolillaRndm = new();
            var bolillaAleatorea = new BolillaModel()
            {
                NumeroBolilla = bolillaRndm.Next(Minimo, Maximo).ToString()
            };
            return bolillaAleatorea;
        }
    }
}
