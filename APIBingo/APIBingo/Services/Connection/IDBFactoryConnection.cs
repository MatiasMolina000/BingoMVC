using System.Data;

namespace APIBingo.Services.Connection
{
    public interface IDBFactoryConnection
    {
        IDbConnection CreateConnection();
    }
}
