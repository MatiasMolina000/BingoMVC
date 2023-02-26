using System.Security.AccessControl;
using JuegoBingoAPI.Data;
using JuegoBingoAPI.Models;
using System.Text.Json;
using System.Data;
using System.Security.Cryptography;

namespace JuegoBingoAPI.Rule
{
    public class BingoRule
    {
        private readonly int _numeroCartones = 4;

        public ResponseModel NewGame(string usuarioId)
        {
            try
            {
                //Creo
                PartidaModel miPartida = new()
                {
                    Fecha = DateTime.Now,
                    EstadoId = 1,
                    UsuarioId = usuarioId
                };

                //Guardo
                BingoData data = new();
                int partidaId = data.NewGame(miPartida);

                var misCartones = new List<CartonModel>();

                for (int i = 1; i <= _numeroCartones; i++)
                {
                    CartonModel carton = new()
                    {
                        NumeroCarton = i,
                        JuegoHistorialId = partidaId
                    };
                    // Guardo Carton
                    int cartonId = data.InsertPlayers(carton);

                    // Guardo Números
                    var nbrs = carton.Numeros.Split(',');
                    string inserts = "";

                    for (var n = 0; n < nbrs.Length; n++) {
                        if (nbrs[n] != "") {
                            if (inserts != "")
                            {
                                inserts += $", ({cartonId}, {nbrs[n]}, 0)";
                            }
                            else 
                            {
                                inserts += $"({cartonId}, {nbrs[n]}, 0)";
                            }
                        }
                    } 
                    data.InsertNumbersPlayers(inserts);

                    var josncartron = JsonSerializer.Serialize(carton);
                    //Agrego al listado de cartones
                    misCartones.Add(carton);
                };
                string jsonString = JsonSerializer.Serialize(misCartones);

                return new ResponseModel()
                {
                    Status = true,
                    Message = "Se han generado los cartones exitosamente!",
                    Data = jsonString
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Status = false,
                    Message = ex.Message,
                    Data = ""
                };
            }
        }
        
        public ResponseModel NewNumber(string partidaId) {

            try
            {
                int numero = 0;
                BolillaModel bolilla = new();

                //Accedo a DB, veo existentes
                BingoData data = new();
                List<BolilleroModel> dataExist = data.GetBolillasCantadas(partidaId);

                if (dataExist.Count == 0)
                {
                    // Creo y asigno
                    var newNumber = bolilla.BolillaAleatorea();
                    numero = Int32.Parse(newNumber.NumeroBolilla);

                }
                else 
                {
                    // Repito hasta crear un número unico
                    bool ok = true;
                    int ifExist = 0;
                    do
                    {
                        var newNumber = bolilla.BolillaAleatorea();
                        //Valido y asigno
                        bool isNumeric = Int32.TryParse(newNumber.NumeroBolilla, out int nro);
                        if (isNumeric)
                        {
                            ifExist = dataExist.Where(Inro => Inro.Numeros == nro).Count();
                            if (ifExist == 0) 
                            {
                                numero = nro;
                                ok = false;
                            }
                        }
                    } while (ok) ;
                };

                BolilleroModel bolillaAGrabar = new()
                {
                    Numeros = numero,
                    Alta = DateTime.Now,
                    JuegoHistorialId = Int32.Parse(partidaId)
                };

                //Grabo registro en la BD
                data.InsertCallBolilla(bolillaAGrabar);

                ResponseModel response = new()
                {
                    Status = true,
                    Message = $"Ha salido el número: {bolillaAGrabar.Numeros}",
                    Data = JsonSerializer.Serialize(bolillaAGrabar)
                };

                if (dataExist.Count >= 14)
                {
                    var checkWinner = data.GetWinners(partidaId);

                    if (checkWinner.Count > 0)
                    {
                        string inserts = "";
                        for (int i = 0; i < checkWinner.Count; i++) {
                            inserts += $", Carton{i + 1} = {checkWinner[i]}"; 
                        }

                        data.UpdateEndGame(partidaId, inserts);
                        
                        response.Message = $"Ganador: carton {checkWinner}";
                        response.Data = JsonSerializer.Serialize(checkWinner);
                    }
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }
        
        /* private static ResponseModel NewGamePlayer(List<CartonModel> cartones)
        {
            var inserts = "";
            try
            {
                //Creo
                foreach (var item in cartones)
                {
                    inserts = $"{item.NumeroCarton}, {item.JuegoHistorialId}, '{item.Numeros}'";
                    // Valido que se ingrese cada uno de los jugadores.
                }
                //Gueardo
                var data = new BingoData();
                var jugadores = data.NewGamePlayers(inserts);

                return new ResponseModel()
                {
                    Status = true,
                    Message = "Partida registrada con éxito!",
                    Data = cartones.ToString()
                };
            }
            catch (Exception)
            {
                return new ResponseModel()
                {
                    Status = false,
                    Message = "Ha ocurrido un error al momento de generar la partida! Intente nuevamente mas tarde...",
                    Data = ""
                };
            }
        }
        */
        /*private static ResponseModel NewGamePlayer(int partidaId, PartidaModel partida)
        {
            var data = new BingoData();
            var inserts = "";
            var count = 1;
            var isOk = true;
            /*try
            {
                foreach (var item in partida.)
                {
                    inserts = $"{count}, {partidaId}, '{item.Numeros}'";
                    var jugador = data.NewGamePlayers(inserts);
                    // Valido que se ingrese cada uno de los jugadores.
                    count++;
                    if (!jugador.Status)
                    {
                        isOk = false;
                    }
                }
                if (isOk)
                {
                    return new ResponseModel()
                    {
                        Status = true,
                        Message = "Partida registrada con éxito!",
                        Data = partida.ToString()
                    };
                }
                else
                {
                    return new ResponseModel()
                    {
                        Status = false,
                        Message = "Ha ocurrido un error al momento de generar la partida! Intente nuevamente mas tarde...",
                        Data = partida.ToString()
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Status = false,
                    Message = ex.Message,
                    Data = ""
                };
            }
        }
        */
        /*public Response NewGame(int usuarioId)
        {
            try
            {
                var data = new BingoData();

                var existe = data.ExistePartida(usuarioId);

                if (existe > 0)
                {
                    return new Response()
                    {
                        Status = false,
                        Message = "Ya existe una Partida sin terminar, desea comomenzar una nueva?",
                        Data = "0"
                    };
                }
                else
                {
                    PartidaDto miPartida = new();
                    miPartida.ArmarPartida(4);
                    var response = data.NuevaPartidaJSON(miPartida);
                    return new Response()
                    {
                        Status = true,
                        Message = "Partida registrada con éxito!",
                        Data = response
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Status = false,
                    Message = ex.Message,
                    Data = "0"
                };
            }
        }*/
    }
}
