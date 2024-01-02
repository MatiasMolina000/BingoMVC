using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services.Connection;
using APIBingo.Services.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDBFactoryConnection _connectionFactory;
        private readonly IEMailNotification _notificationEMail;
        private readonly IConfiguration _iConfiguration;


        public UsersController(IDBFactoryConnection connectionFactory, IEMailNotification notificationEMail, IConfiguration iConfiguration)
        { 
            _connectionFactory = connectionFactory;
            _notificationEMail = notificationEMail;
            _iConfiguration = iConfiguration;
        }


        [HttpPost("New")]
        public async Task<ResultResponse<UserRequest>> New([FromBody] UserRequest oModel) 
        {
            ResultResponse<UserRequest> rule = await new UserRule(_connectionFactory).New(oModel, _notificationEMail);
            return rule;
        }

        [HttpPost("EMailValidation")]
        public async Task<ResultResponse<bool>> EMailValidation([FromBody] string validationCode)
        {
            string nameIdClaim = string.Empty;

            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                nameIdClaim = HttpContext.User.FindFirstValue("nameid");

            ResultResponse<bool> rule = await new UserRule(_connectionFactory).EMailValidation(nameIdClaim, validationCode);
            return rule;
        }

        [HttpPut("Update")]
        public async Task<ResultResponse<UserRequest>> Update([FromBody] UserRequest oModel) 
        {
            UserModel oAuth = new();

            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                oAuth.Id = 0;
                oAuth.User = HttpContext.User.Identity.Name ?? "";
                oAuth.Email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "";
                oAuth.Password = HttpContext.User.FindFirstValue("password");
                if (int.TryParse(HttpContext.User.FindFirstValue("nameid"), out int numId))
                    oAuth.Id = numId;
            }  

            ResultResponse<UserRequest> rule = await new UserRule(_connectionFactory, _iConfiguration).Update(oModel, oAuth, _notificationEMail);
            return rule;
        }
    }
}
