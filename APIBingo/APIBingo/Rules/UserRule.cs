using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Services;
using APIBingo.Services.Connection;
using APIBingo.Services.Notification;
using System.ComponentModel.DataAnnotations;

namespace APIBingo.Rules
{
    public class UserRule
    {
        private readonly IConfiguration? _iConfiguration;
        private readonly IDBFactoryConnection _connectionFactory;


        public UserRule(IConfiguration iConfiguration, IDBFactoryConnection connectionFactory)
        { 
            _iConfiguration = iConfiguration;
            _connectionFactory = connectionFactory;
        }

        public UserRule(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<ResultResponse<UserRequest>> New(UserRequest oModel, IEMailNotification notificationEMail)
        {
            ResultResponse<UserRequest> response = new() { Data = oModel };

            var exist = await new UserData(_connectionFactory)
                .CheckByUserOrEMail(oModel);

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
                    new EMailNotificationService(notificationEMail)
                        .ValidationMail(oUser.Email, oUser.PassTemp);
                }
            }

            return response;
        }

        public async Task<ResultResponse<bool>> EMailValidation(string? nameId, string code) 
        {
            ResultResponse<bool> response = new();
            UserModel? oUser = await new UserData(_connectionFactory)
                .GetById(nameId ?? "");

            if (oUser == null || oUser.PassTemp != code)
            {
                response.Message = "Unauthorized.";
            }
            else 
            {
                response.Message = await new UserData(_connectionFactory)
                    .EMailValidator(oUser);

                if (response.Message == null)
                {
                    response.Success = true;
                    response.Data = true;
                }
            }
            return response;
        }

        public async Task<ResultResponse<UserRequest>> Update(UserRequest oModel, UserModel oAuth, IEMailNotification notificationEMail)
        {
            ResultResponse<UserRequest> response = new() { Data = oModel };

            UserModel? oUser = await new UserData(_connectionFactory)
                .GetById(oAuth.Id.ToString());
            if (oUser == null 
                || (oUser.User != oAuth.User 
                || oUser.Email != oAuth.Email 
                || oUser.Password != oAuth.Password))
            {
                response.Message = "Unauthorized.";
            }
            else
            {
                oAuth.User = oModel.User;
                oAuth.Email = oModel.Email;
                var exist = await new UserData(_connectionFactory)
                    .CheckUpdatesByUserOrEMail(oAuth);

                if (exist)
                {
                    response.Message = "The user or email already exist.";
                }
                else 
                {
                    if (oUser.User != oModel.User 
                        || oUser.Email != oModel.Email 
                        || oUser.Password != oModel.Password) 
                    {
                        if (oModel.Email == null 
                            || !new EmailAddressAttribute().IsValid(oModel.Email))
                        {
                            response.Message = "The email format is not valid.";
                        }
                        else 
                        {
                            var changesEMail = false;
                            oUser.User = oModel.User;
                            oUser.Password = oModel.Password;
                            
                            if (oUser.Email != oModel.Email)
                            {
                                oUser.Email = oModel.Email;
                                Random rnd = new();
                                int rndNum = rnd.Next(1000, 1000000);
                                oUser.PassTemp = rndNum.ToString();
                                oUser.StatusId = 3;
                                changesEMail = true;
                            }

                            response.Message = await new UserData(_connectionFactory).Update(oUser);
                            if (response.Message == null)
                            {
                                AuthRequest oAuthReq = new()
                                {
                                    Email = oUser.Email,
                                    Password = oUser.Password
                                };
                                ResultResponse<AuthToResponse> auth = await new AuthRules(_iConfiguration, _connectionFactory)
                                    .Authentication(oAuthReq);


                                response.Message = auth.Data?.Token;
                                response.Success = true;

                                if (changesEMail)
                                { 
                                    new EMailNotificationService(notificationEMail)
                                        .ValidationMail(oUser.Email, oUser.PassTemp);
                                }
                            }
                        }
                    }
                    else
                    {
                        response.Message = "There are not changes to save.";
                    }
                }
            }
            return response;
        }
    }
}
