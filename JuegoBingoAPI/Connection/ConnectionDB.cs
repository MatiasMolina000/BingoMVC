using Microsoft.Extensions.Configuration;

namespace JuegoBingoAPI.Connection
{
    public class ConnectionDB
    {
        private readonly string _connectionString = string.Empty;
        public ConnectionDB()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            _connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;

        }

        public string ConnectionStringSQL() 
        {
            return _connectionString;
        }

        
    }
}
