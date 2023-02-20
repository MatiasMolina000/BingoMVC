using System.Security.AccessControl;
using JuegoBingoAPI.Data;
using JuegoBingoAPI.Models;
using System.Text.Json;

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
                var data = new BingoData();
                var dataResult = data.NewGame(miPartida);

                //Valido
                bool isNumeric = Int32.TryParse(dataResult.Data, out int partidaId);
                if (isNumeric)
                {
                    //Creo
                    var misCartones = new List<CartonModel>();

                    for (int i = 1; i <= _numeroCartones; i++)
                    {
                        CartonModel carton = new()
                        {
                            NumeroCarton = i,
                            JuegoHistorialId = partidaId
                        };
                        misCartones.Add(carton);
                    };

                    //Guardo
                    var cartones = NewGamePlayer(misCartones);

                    //Devuelvo
                    string jsonString = JsonSerializer.Serialize(misCartones);

                    return new ResponseModel()
                    {
                        Status = true,
                        Message = "Se han generado los cartones exitosamente!",
                        Data = jsonString
                    };
                }
                else 
                {
                    return new ResponseModel()
                    {
                        Status = false,
                        Message = "Ha ocurrido un error!",
                        Data = ""
                    };

                }
                
                /*var data = new BingoData();
                var partidaId = data.NewGame(miPartida);*/
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
        private static ResponseModel NewGamePlayer(List<CartonModel> cartones)
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
