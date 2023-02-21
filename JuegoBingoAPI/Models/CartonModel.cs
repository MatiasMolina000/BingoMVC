namespace JuegoBingoAPI.Models
{
    public class CartonModel
    {
        // 1ra Declaración de variables (Necesarias para delimitar el armado del cartón)
        public readonly int _filas = 3;
        public readonly int _columnas = 9;
        private readonly int _valorMin = 1;
        private readonly int _valorMax = 10;
        // 2da Declaración de variables (Necesarias para ordenar y limitar la cantidad de números,
        // maximo 15 números, 3 columnas con 1 espacio vacío y 6 con 2 espacios vacíos)
        private int _celdaAct = 0;
        private int _celdaAnt = 0;
        private int _nVuelta;
        // 3ra Declaracion y asignación  de variables (Necesarias para definir posiciones de números respetando 5 valores por fila)
        //private int _celdaAnt1 = -1;
        //private int _celdaAct1 = 0;
        private int _fila0 = 0;
        private int _fila1 = 0;
        // 4ta Declaración y asignación de variables (Necesaria para armado de carton final con números aleatorios diferentes)
        private int _numeroAct = 0;
        private int _numeroAnt = 0;

        public int ID { get; set; }
        public int NumeroCarton { get; set; }
        public int JuegoHistorialId { get; set; }
        public string Numeros { get; set; }

        public CartonModel()
        {
            int[,] carton = new int[_filas, _columnas];
            string numeros = "";

            // 1 - Genero matriz con rangos minimos y máximos de números que puede tener el cartón por columna
            int[,] rangos = new int[_filas - 1, _columnas];
            for (var c = 0; c < _columnas; c++)
            {
                if (c == _columnas - 1)
                {
                    _valorMax += 1;
                    rangos[0, c] = _valorMin;
                    rangos[1, c] = _valorMax;
                }
                else
                {
                    rangos[0, c] = _valorMin;
                    rangos[1, c] = _valorMax;
                }
                _valorMin = _valorMax;
                _valorMax += 10;
            }

            // 2 - Defino tres distintas columnas con 2 campos en vacío
            int[] numXColumnas = new int[_columnas];
            for (var r = 0; r < 3; r++)
            {
                do
                {
                    Random columnasEnBlancoAleatorias = new();
                    _celdaAct = columnasEnBlancoAleatorias.Next(0, _columnas - 1);

                    // Condicional If para minimizar columnas de 2 campos vacíos seguidas
                    if (_celdaAct == _celdaAnt + 1)
                    {
                        Random nuevaVuelta = new();
                        _nVuelta = nuevaVuelta.Next(0, 1);
                        if (_nVuelta == 1)
                        {
                            _celdaAct = _celdaAnt;
                        }
                    }
                } while (_celdaAct == _celdaAnt);

                numXColumnas[_celdaAct] = 2;
                _celdaAnt = _celdaAct;
            }

            // 3 - Asigno las restantes con 1 solo campo vacío
            for (var r = 0; r < _columnas; r++)
            {
                if (numXColumnas[r] != 2)
                {
                    numXColumnas[r] = 1;
                }
            }

            // 4 - Defino que campos tendrán números y los que estarán vacíos
            for (var f = 0; f < 2; f++)
            {
                // Cinco campos llenos en la primera fila
                if (f == 0)
                {
                    do
                    {
                        _fila0 = 0;
                        for (int c0 = 0; c0 < 9; c0++)
                        {
                            Random celdaEnBlancoAleatoria = new();
                            carton[f, c0] = celdaEnBlancoAleatoria.Next(0, 3);
                            if (carton[f, c0] > 0)
                            {
                                carton[f, c0] = 1;
                                _fila0 += 1;
                                if (_fila0 == 5)
                                {
                                    break;
                                }
                            }
                        }
                    } while (_fila0 != 5);
                }
                // Cinco campos llenos en las siguientes filas
                else if (f == 1)
                {
                    do
                    {
                        _fila1 = 0;
                        for (int c1 = 0; c1 < 9; c1++)
                        {
                            if (carton[f - 1, c1] == 1 && numXColumnas[c1] == 2)
                            {
                                carton[f, c1] = 0;
                                carton[f + 1, c1] = 0;
                            }
                            else if (carton[f - 1, c1] == 0 && numXColumnas[c1] == 1)
                            {
                                carton[f, c1] = 1;
                                carton[f + 1, c1] = 1;
                            }
                            else if (numXColumnas[c1] == 2 && carton[f - 1, c1] == 0)
                            {
                                Random celdaEnBlancoAleatoria = new();
                                carton[f, c1] = celdaEnBlancoAleatoria.Next(0, 3);
                                if (carton[f, c1] > 0)
                                {
                                    carton[f, c1] = 1;
                                    carton[f + 1, c1] = 0;
                                }
                                else
                                {
                                    carton[f + 1, c1] = 1;
                                }
                            }
                            else if (numXColumnas[c1] == 1 && carton[f - 1, c1] == 1)
                            {
                                
                                Random celdaEnBlancoAleatoria = new();
                                carton[f, c1] = celdaEnBlancoAleatoria.Next(0, 3);
                                if (carton[f, c1] > 0)
                                {
                                    carton[f, c1] = 1;
                                    carton[f + 1, c1] = 0;
                                }
                                else
                                {
                                    carton[f + 1, c1] = 1;
                                }
                            }
                            _fila1 += carton[f, c1];
                        }
                    } while (_fila1 != 5);
                }
            }

            // 5 - Asigno números aleatorios a la matriz que representa los cartones de bingo
            for (var c = 0; c < 9; c++)
            {
                // Declaración de variables y asignación para disminuir líneas
                int Num1 = 0;
                int Num2 = 0;
                int Pos1 = 0;
                int Pos2 = 0;

                for (int f = 0; f < 3; f++)
                {
                    if (carton[f, c] == 1)
                    {
                        do
                        {
                            Random numeroAleatorio = new();
                            _numeroAct = numeroAleatorio.Next(rangos[0, c], rangos[1, c]);
                        } while (_numeroAct == _numeroAnt);
                        carton[f, c] = _numeroAct;
                        _numeroAnt = _numeroAct;

                        // Almaceno los valores de columnas con 2 números para ordenar luego
                        if (numXColumnas[c] == 1)
                        {
                            if (Num1 == 0)
                            {
                                Num1 = carton[f, c];
                                Pos1 = f;
                            }
                            else
                            {
                                Num2 = carton[f, c];
                                Pos2 = f;
                            }
                        }
                    }
                }
                // Ordeno verticalmente si fuese necesario
                if (Num1 > Num2)
                {
                    carton[Pos1, c] = Num2;
                    carton[Pos2, c] = Num1;

                }
            }

            //Numeros = carton;

            for (int c = 0; c < 9; c++)
            {
                for (int f = 0; f < 3; f++)
                {
                    if (f == 0 && c == 0)
                    {
                        if (carton[f, c] != 0) {
                            numeros = carton[f, c].ToString();
                        }
                    }
                    else 
                    {
                        numeros += ",";
                        if (carton[f, c] > 0) 
                        {
                            numeros += carton[f, c].ToString();
                        }
                    }
                    
                    //numeros = numeros + carton[f, c].ToString() + ";";
                }
            }
            Numeros = numeros;

        }

        /*public List<CartonModel> ArmarJego(int cantidades)
        {
            var misCartones = new List<CartonModel>();

            for (int i = 0; i < cantidades; i++)
            {
                var carton = new CartonModel();
                carton.NumeroCarton = i;

                misCartones.Add(carton);
            }

            return misCartones;
        }*/

    }
}
