namespace JuegoBingoMVC.Models
{
    public class Bolilla
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
        public bool Estado { get; set; }

        public Bolilla() { }

        public Bolilla BolillaAleatorea()
        {
            Random bolillaRndm = new();
            var bolillaAleatorea = new Bolilla()
            {
                NumeroBolilla = bolillaRndm.Next(Minimo, Maximo).ToString(),
                Estado = true
            };
            return bolillaAleatorea;
        }

        //public List<Bolilla> Llenar()
        //{
        //    var bolilla = new List<Bolilla>();

        //    for (int i = _valorMinimo; i <= _valorMaximo; i++)
        //    {
        //        Bolilla n = new()
        //        {
        //            NumeroBolilla = i.ToString(),
        //            Estado = true
        //        };
        //        bolilla.Add(n);
        //    };
        //    return bolilla;
        //}

    }
}
