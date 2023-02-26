using JuegoBingoAPI.Connection;
using Dapper;
using System.Data.SqlClient;
using JuegoBingoAPI.Models;
using System.Collections.Generic;

namespace JuegoBingoAPI.Data
{
    public class BingoData
    {
        public int NewGame(PartidaModel partida)
        {
            string query = $"INSERT INTO HistorialCartones (Fecha, EstadoId, UsuarioId) VALUES (GETDATE(), @EstadoId, @UsuarioId); SELECT SCOPE_IDENTITY()";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.ExecuteScalar<int>(query, partida, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }

        public int InsertPlayers(CartonModel carton)
        {
            string query = $"INSERT INTO Cartones (NumeroCarton, JuegoHistorialId, Numeros) VALUES (@NumeroCarton, @JuegohistorialId, @Numeros); SELECT SCOPE_IDENTITY()";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.ExecuteScalar<int>(query, carton, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }

        public int InsertNumbersPlayers(string inserts)
        {
            string query = $"INSERT INTO NumerosCarton(CartonId, Numero, Estado) VALUES{inserts}";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.Execute(query, inserts, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }

        public int NewGamePlayers(string insert)
        {
            string query = $"INSERT INTO Cartones (NumeroCarton, JuegohistorialId, Numeros) VALUES ({insert})";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.ExecuteScalar<int>(query, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<BolilleroModel> GetBolillasCantadas(string partidaId) {

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            string query = $"SELECT * FROM HistorialBolillero WITh(NOLOCK) WHERE JuegoHistorialId = {partidaId} ORDER BY Alta";

            var bolillero = cnn.Query<BolilleroModel>(query).ToList();

            return bolillero;
        }

        public int InsertCallBolilla(BolilleroModel bolilla)
        {
            string query = $"INSERT INTO HistorialBolillero (Numeros, Alta, JuegoHistorialId) VALUES (@Numeros, @Alta, @JuegoHistorialId);" +
                           $"UPDATE NumerosCarton SET Estado = 1 WHERE EXISTS(SELECT ID FROM Cartones c WHERE NumerosCarton.CartonId = c.ID " +
                           $"   AND c.JuegoHistorialId = @JuegoHistorialId AND NumerosCarton.Numero = @Numeros)";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.Execute(query, bolilla, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }

        }

        public List<string> GetWinners(string partidaId) {

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            string query = $"SELECT c.NumeroCarton, COUNT(nc.Numero) FROM NumerosCarton nc WITH(NOLOCK) " +
                           $"  INNER JOIN Cartones c WITH(NOLOCK) ON nc.CartonId = c.ID " +
                           $"WHERE c.JuegoHistorialId = {partidaId} AND nc.Estado = 1 GROUP BY c.NumeroCarton HAVING COUNT(nc.Numero) = 15";

            var winners = cnn.Query<string>(query).ToList();

            return winners;
        }

        public int UpdateEndGame(string partidaId, string inserts)
        {

            string query = $"UPDATE HistorialCartones SET Fecha = GETDATE(){inserts} WHERE ID = {partidaId}";

            using var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL());

            cnn.Open();
            var trn = cnn.BeginTransaction();
            try
            {
                int response = cnn.Execute(query, inserts, trn);
                trn.Commit();
                return response;
            }
            catch (Exception)
            {
                trn.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }

        public ResponseModel LoadGame()
        {
            using (var cnn = new SqlConnection(new ConnectionDB().ConnectionStringSQL()))
            {
                string query = "SELECT hc.Id FROM HistorialCartones hc WITH(NOLOCK) INNER JOIN AspNetUsers u WITH(NOLOCK) ON hc.UsuarioId = u.ID AND hc.EstadoId = 1";

                ResponseModel response = new();

                try
                {
                    cnn.Open();
                    int partidaId = cnn.ExecuteScalar<int>(query);

                    response.Status = true;
                    response.Data = partidaId.ToString();
                    
                    
                }
                catch (Exception)
                {
                    response.Status = false;

                    throw;

                }
                finally
                {
                    cnn.Close();
                }
                return response;
            };
        }


    }
}
