using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Models.Response;
using APIBingo.Services.Connection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIBingo.Rules
{
    public class AuthRules
    {
        private readonly IConfiguration _iConfiguration;
        private readonly IDBFactoryConnection _connectionFactory;


        public AuthRules(IConfiguration iConfiguration, IDBFactoryConnection connectionFactory) 
        { 
            _iConfiguration = iConfiguration;
            _connectionFactory = connectionFactory;
        } 


        public async Task<ResultResponse<AuthToResponse>> Authentication(AuthRequest oAuthReq)
        {
            ResultResponse<AuthToResponse> response = new() { Message = "Access denied." };

            UserModel? auth = await new AuthData(_connectionFactory).Authentication(oAuthReq);

            if (auth != null) 
            { 
                string token = GetToken(auth, _iConfiguration);
                response.Success = true;
                response.Message = "Authentication successfull.";
                
                response.Data = new AuthToResponse(token, auth);
            }

            return response;
        }

        private static string GetToken(UserModel oModel, IConfiguration iConfiguration)
        {
            ClaimsIdentity subject = new(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, oModel.User),
                new Claim(JwtRegisteredClaimNames.Email, oModel.Email)
            });
            subject.AddClaim(new Claim("nameId", oModel.Id.ToString()));
            subject.AddClaim(new Claim("password", oModel.Password));

            string issuer = iConfiguration["Jwt:Issuer"];
            string audience = iConfiguration["Jwt:Audience"];
            byte[] key = Encoding.ASCII.GetBytes(iConfiguration["Jwt:Key"]);
            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
