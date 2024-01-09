using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services;
using APIBingo.Services.Connection;
using APIBingo.Services.Notification;
using Microsoft.AspNetCore.Mvc;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _iConfiguration;
        private readonly IDBFactoryConnection _connectionFactory;
        private readonly IEMailNotification _notificationEMail;


        public UsersController(IConfiguration iConfiguration, IDBFactoryConnection connectionFactory, IEMailNotification notificationEMail)
        { 
            _iConfiguration = iConfiguration;
            _connectionFactory = connectionFactory;
            _notificationEMail = notificationEMail;
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
            GetAuthenticationService getAuth = new(HttpContext);
            var nameIdClaim = getAuth.GetId();

            ResultResponse<bool> rule = await new UserRule(_connectionFactory).EMailValidation(nameIdClaim, validationCode);
            return rule;
        }

        [HttpPut("Update")]
        public async Task<ResultResponse<UserRequest>> Update([FromBody] UserRequest oModel) 
        {
            GetAuthenticationService getAuth = new(HttpContext);
            UserModel oAuth = new()
            {
                Id = int.Parse(getAuth.GetId() ?? "0"),
                User = getAuth.GetUser() ?? "",
                Email = getAuth.GetEmail() ?? "",
                Password = getAuth.GetPassword() ?? ""
            };

            ResultResponse<UserRequest> rule = await new UserRule(_iConfiguration, _connectionFactory).Update(oModel, oAuth, _notificationEMail);
            return rule;
        }
    }
}
