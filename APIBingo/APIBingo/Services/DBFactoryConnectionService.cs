using APIBingo.Services.Connection;
using Dapper;
using System.Data;

namespace APIBingo.Services
{
    public class DBFactoryConnectionService
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public DBFactoryConnectionService(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        //Return one element. It doesn't matters the object/data type.
        public async Task<T?> ExecuteGetSingleObjectAsync<T>(string query, object? parameters)
        {
            using IDbConnection cnn = _connectionFactory.CreateConnection();
            try
            {
                T? data = await cnn.QueryFirstOrDefaultAsync<T>(query, parameters);
                cnn.Close();
                return data;
            }
            catch (Exception)
            {
                cnn.Close();
                return default;
            }
        }

        //Execute and return number of rows afected or las id (using SELECT SCOPE_IDENTITY())
        public async Task<string?> ExecuteInsertSingleStringAsync(string query, object? parameters)
        {
            string? response = null;

            using (IDbConnection cnn = _connectionFactory.CreateConnection())
            {
                cnn.Open();
                var trn = cnn.BeginTransaction();
                try
                {
                    int data = await cnn.ExecuteAsync(query, parameters, trn);
                    response = data.ToString();
                    trn.Commit();
                }
                catch (Exception)
                {
                    trn.Rollback();
                }
                finally
                {
                    cnn.Close();
                }
            }
            return response;
        }
    }
}
