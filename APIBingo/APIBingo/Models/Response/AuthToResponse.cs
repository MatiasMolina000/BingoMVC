using APIBingo.Models.Request;

namespace APIBingo.Models.Response
{
    public class AuthToResponse
    {
        public string Token { get; set; }
        public UserRequest User { get; set; }

        public AuthToResponse(string token, UserModel oModel)
        {
            Token = token;
            User = new()
            {
                User = oModel.User,
                Email = oModel.Email,
                Password = oModel.Password
            };
        }
    }
}
