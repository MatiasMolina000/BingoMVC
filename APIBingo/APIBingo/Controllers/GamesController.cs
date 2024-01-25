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

        public GamesController(IDBFactoryConnection connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        [HttpPost("New")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> New()
        {
            // Control the user authentication in the token.
            var userId = GetAuthenticatedUserId();

            if (userId != null)
            {
                // Funcionality that creates a new game.
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory)
                    .New((int)userId);

                return rule;
            }
            
            return new ResultResponse<BingoGameDataTransferObject>() 
            { 
                Message = "Unauthorized." 
            };
        }

        [HttpPut("DropBall")]
        public async Task<ResultResponse<BingoCageDataTransferObject>> DropBall(int gameId)
        {
            // Control the user authentication in the token.
            var userId = GetAuthenticatedUserId();

            if (userId != null)
            {
                // Functionality that calls a new ball in the game and controls it.
                ResultResponse<BingoCageDataTransferObject> rule = await new GameRule(_connectionFactory)
                    .DropBall((int)userId, gameId);

                return rule;
            }

            return new ResultResponse<BingoCageDataTransferObject>() 
            { 
                Message = "Unauthorized." 
            };
        }

        [HttpGet("Load")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> Load()
        {
            // Control the user authentication in the token.
            var userId = GetAuthenticatedUserId();

            if (userId != null)
            {
                // Funcionality that loads a new game.
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory)
                    .Load((int)userId);

                return rule;
            }

            return new ResultResponse<BingoGameDataTransferObject>() 
            { 
                Message = "Unauthorized." 
            };
        }

        [HttpPatch("Close")]
        public async Task<ResultResponse<BingoGameDataTransferObject>> Close()
        {
            // Control the user authentication in the token.
            var userId = GetAuthenticatedUserId();

            if (userId != null)
            {
                // Funcionality that closes a new game.
                ResultResponse<BingoGameDataTransferObject> rule = await new GameRule(_connectionFactory)
                    .Close((int)userId);
                
                return rule;
            }

            return new ResultResponse<BingoGameDataTransferObject>() 
            { 
                Message = "Unauthorized." 
            };
        }

        private int? GetAuthenticatedUserId()
        {
            // Services that search in the token and return the request.
            GetAuthenticationService getAuthenticationService = new(HttpContext);
            string? authenticationId = getAuthenticationService.GetId();
            
            // Validation of the user id.
            if (string.IsNullOrEmpty(authenticationId))
            {
                return null;
            }
            if (!int.TryParse(authenticationId, out int userId))
            {
                return null;
            }

            return userId;
        }
    }
}
