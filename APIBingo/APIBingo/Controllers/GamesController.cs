using APIBingo.Models.DataTransferObject;
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
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IDBFactoryConnection _connectionFactory;

        public GamesController( IDBFactoryConnection connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        [HttpPost("New")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> New()
        {
            GetAuthenticationService getAuth = new(HttpContext);
            var authId = getAuth.GetId();

            if (!string.IsNullOrEmpty(authId) && int.TryParse(authId, out int userId)) 
            { 
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory).New(userId);
                return rule;
            }
            return new ResultResponse<BingoGameDataTransferObject>() { Message = "Unauthorized." };
        }

        [HttpPut("DropBall")]
        public async Task<ResultResponse<BingoCageDataTransferObject>> DropBall(int gameId)
        {
            GetAuthenticationService getAuth = new(HttpContext);
            var authId = getAuth.GetId();

            if (!string.IsNullOrEmpty(authId) && int.TryParse(authId, out int userId))
            {
                ResultResponse<BingoCageDataTransferObject> rule = await new GameRule(_connectionFactory).DropBall(userId, gameId);
                return rule;
            }
            return new ResultResponse<BingoCageDataTransferObject>() { Message = "Unauthorized." };
        }

        [HttpGet("Load")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> Load() 
        {
            GetAuthenticationService getAuth = new(HttpContext);
            var authId = getAuth.GetId();

            if (!string.IsNullOrEmpty(authId) && int.TryParse(authId, out int userId))
            {
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory).Load(userId);
                return rule;
            }
            return new ResultResponse<BingoGameDataTransferObject>() { Message = "Unauthorized." };
        }

        [HttpPatch("Close")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> Close()
        {
            GetAuthenticationService getAuth = new(HttpContext);
            var authId = getAuth.GetId();

            if (!string.IsNullOrEmpty(authId) && int.TryParse(authId, out int userId))
            {
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory).Close(userId);
                return rule;
            }
            return new ResultResponse<BingoGameDataTransferObject>() { Message = "Unauthorized." };
        }
    }
}
