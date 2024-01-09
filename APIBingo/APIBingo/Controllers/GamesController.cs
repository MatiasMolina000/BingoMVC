using APIBingo.Models;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services.Connection;
using Microsoft.AspNetCore.Mvc;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IDBFactoryConnection _connectionFactory;

        public GamesController( IDBFactoryConnection connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        [HttpPost("New")]
        public async Task<ResultResponse<GameModel>> New([FromBody] int userId)
        {
            ResultResponse<GameModel> rule = await new GameRule(_connectionFactory).New(userId);
            return rule;
        }
    }
}
