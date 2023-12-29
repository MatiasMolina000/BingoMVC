using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Rules;
using APIBingo.Services.Connection;
using APIBingo.Services.Notification;
using Microsoft.AspNetCore.Mvc;

namespace APIBingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDBFactoryConnection _connectionFactory;
        private readonly IEMailNotification _notificationEMail;


        public UsersController(IDBFactoryConnection connectionFactory, IEMailNotification notificationEMail)
        { 
            _connectionFactory = connectionFactory;
            _notificationEMail = notificationEMail;
        }


        [HttpPost("New")]
        public async Task<ResultResponse<UserRequest>> New([FromBody] UserRequest oModel) 
        {
            ResultResponse<UserRequest> rule = await new UserRule(_connectionFactory).New(oModel, _notificationEMail);
            return rule;
        }
    }
}
