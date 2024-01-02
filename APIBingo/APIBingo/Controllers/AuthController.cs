using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services.Connection;
using Microsoft.AspNetCore.Mvc;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _iConfiguration;
        private readonly IDBFactoryConnection _connectionFactory;


        public AuthController(IConfiguration iConfiguration, IDBFactoryConnection connectionFactory)
        { 
            _iConfiguration = iConfiguration; 
            _connectionFactory = connectionFactory;
        } 


        [HttpPost("Authentication")]
        public async Task<ResultResponse<TokenModel>> Authentication([FromBody] AuthRequest oModel) 
        {
            ResultResponse<TokenModel> auth = await new AuthRules(_iConfiguration, _connectionFactory).Authentication(oModel, _iConfiguration);
            return auth;
        }
    }
}
