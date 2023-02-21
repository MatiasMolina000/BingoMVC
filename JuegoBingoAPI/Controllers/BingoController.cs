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
        public ResponseModel NewGame(string usuarioId)
        {
            var rule = new BingoRule();
            return rule.NewGame(usuarioId);
        }

        [HttpPost("NewNumber")]
        public ResponseModel NewNumber(string partidaId)
        {
            var rule = new BingoRule();
            return rule.NewNumber(partidaId);
        }
    }
}
