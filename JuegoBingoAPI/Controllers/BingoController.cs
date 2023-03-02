using Microsoft.AspNetCore.Mvc;
using JuegoBingoAPI.Models;
using JuegoBingoAPI.Rule;


namespace JuegoBingoAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BingoController : ControllerBase
    {
        [HttpPost("NewGame")]
        public ResponseModel NewGame(string usuarioName)
        {
            var rule = new BingoRule();
            return rule.NewGame(usuarioName);
        }

        [HttpPost("NewNumber")]
        public ResponseModel NewNumber(string partidaId)
        {
            var rule = new BingoRule();
            return rule.NewNumber(partidaId);
        }

        [HttpGet("GetParty")]
        public ResponseModel GetParty(string usuarioName)
        {
            var rule = new BingoRule();
            return rule.GetParty(usuarioName);
        }
    }
}
