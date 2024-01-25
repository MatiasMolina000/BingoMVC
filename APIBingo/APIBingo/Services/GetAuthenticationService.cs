using APIBingo.Services.ClaimsToken;
using System.Security.Claims;

namespace APIBingo.Services
{
    public class GetAuthenticationService
    {
        private readonly HttpContext _httpContext;
        private static bool s_authenticated;

        public GetAuthenticationService(HttpContext httpContext)
        { 
            _httpContext = httpContext;
            if (!new GetAuthentication(_httpContext).ValidateAuthentication())
            { 
                s_authenticated = true;
            }
        }
        

        public string? GetId()
        {
            if (s_authenticated) 
            {
                return null;
            }

            var claim = "";
            if (int.TryParse(_httpContext.User.FindFirstValue("nameid"), out int id)) 
            { 
                claim = id.ToString();
            }
            
            return claim;
        }


        public string? GetEmail()
        {
            if (s_authenticated)
            { 
                return null;
            }

            string claim = _httpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "";
            
            return claim;
        }

        public string? GetPassword()
        {
            if (s_authenticated)
            {
                return null;
            }

            string claim = _httpContext.User.FindFirstValue("password") ?? "";
            
            return claim;
        }

        public string? GetUser()
        {
            if (s_authenticated)
            { 
                return null;
            }

            string claim = _httpContext.User.Identity?.Name ?? "";
            
            return claim;
        }
    }
}
