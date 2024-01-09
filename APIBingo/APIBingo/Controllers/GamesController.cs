using APIBingo.Models;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services;
using APIBingo.Services.Connection;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("New")]
        public async Task<ResultResponse<GameModel>> New()
        {
            GetAuthenticationService getAuth = new(HttpContext);
            var authId = getAuth.GetId();

            if (!string.IsNullOrEmpty(authId) && int.TryParse(authId, out int userId)) 
            { 
                ResultResponse<GameModel> rule = await new GameRule(_connectionFactory).New(userId);
                return rule;
            }
            return new ResultResponse<GameModel>() { Message = "Unauthorized." };
        }
    }
}
