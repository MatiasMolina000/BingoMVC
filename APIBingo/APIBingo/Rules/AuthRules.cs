using APIBingo.Datas;
using APIBingo.Models;
using APIBingo.Models.Request;
using APIBingo.Services.Connection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace APIBingo.Rules
{
    public class AuthRules
    {
        private readonly IDBFactoryConnection _connectionFactory;


        public AuthRules(IDBFactoryConnection connectionFactory) => _connectionFactory = connectionFactory;


        public async Task<string?> Authentication(UserRequest oUserReq, IConfiguration iConfig)
        {
            string? token = string.Empty;
            UserModel? auth = await new AuthData(_connectionFactory).Authentication(oUserReq);
            if (auth != null) token = GetToken(auth, iConfig);
            return token;
        }

        private static string? GetToken(UserModel oModel, IConfiguration iConfig)
        {
            ClaimsIdentity subject = new(new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, oModel.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, oModel.User),
                new Claim(JwtRegisteredClaimNames.Email, oModel.Email)
            });
            subject.AddClaim(new Claim("Password", oModel.Password));

            string issuer = iConfig["Jwt:Issuer"];
            string audience = iConfig["Jwt:Audience"];
            byte[] key = Encoding.ASCII.GetBytes(iConfig["Jwt:Key"]);
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
            string? jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
