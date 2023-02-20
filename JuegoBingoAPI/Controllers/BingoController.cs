using Microsoft.AspNetCore.Mvc;
using JuegoBingoAPI.Models;
using JuegoBingoAPI.Rule;


namespace JuegoBingoAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BingoController : ControllerBase
    {
        [HttpPost("NewPartidaGuardada")]
        public ResponseModel NewGame(string usuarioId)
        {
            var rule = new BingoRule();
            return rule.NewGame(usuarioId);
        }
    }
}
