using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services.Connection;
using Microsoft.AspNetCore.Mvc;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public UsersController(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        [HttpPost("New")]
        public async Task<ResultResponse<UserRequest>> New([FromBody] UserRequest oModel) 
        {
            ResultResponse<UserRequest> rule = await new UserRule(_connectionFactory).New(oModel);
            return rule;
        }
    }
}
