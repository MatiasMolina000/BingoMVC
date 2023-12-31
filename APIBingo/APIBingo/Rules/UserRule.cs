using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Services;
using APIBingo.Services.Connection;
using APIBingo.Services.Notification;

namespace APIBingo.Rules
{
    public class UserRule
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public UserRule(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<ResultResponse<UserRequest>> New(UserRequest oModel, IEMailNotification notificationEMail)
        {
            ResultResponse<UserRequest> response = new() { Data = oModel };

            var exist = await new UserData(_connectionFactory).CheckByUserOrEMail(oModel);
            if (exist)
            {
                response.Message = "The user or email already exist.";
            }
            else 
            {
                Random rnd = new();
                int rndNum = rnd.Next(1000, 1000000);

                UserModel oUser = new()
                {
                    User = oModel.User,
                    Email = oModel.Email,
                    Password = oModel.Password,
                    PassTemp = rndNum.ToString(),
                };
                response.Message = await new UserData(_connectionFactory).New(oUser);
                if (response.Message == null)
                {
                    response.Success = true;
                    new EMailNotificationService(notificationEMail).ValidationMail(oUser.Email, oUser.PassTemp);
                }
            }

            return response;
        }

        public async Task<ResultResponse<bool>> EMailValidation(string? nameId, string code) 
        {
            ResultResponse<bool> response = new();
            UserModel? oUser = await new UserData(_connectionFactory).GetById(nameId ?? "");
            if (oUser == null || oUser.PassTemp != code)
            {
                response.Message = "Unauthorized.";
            }
            else 
            {
                response.Message = await new UserData(_connectionFactory).EMailValidator(oUser);
                if (response.Message == null)
                {
                    response.Success = true;
                    response.Data = true;
                }
            }
            return response;
        }
    }
}
