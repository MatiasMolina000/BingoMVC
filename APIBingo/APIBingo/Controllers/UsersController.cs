using APIBingo.Models.Request;
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
        public async Task<IActionResult> New([FromBody] UserRequest oModel) 
        {
            var rule = await new UserRule(_connectionFactory).New(oModel);
            if (rule != null) return BadRequest(rule);
            return Ok();
        }
    }
}
