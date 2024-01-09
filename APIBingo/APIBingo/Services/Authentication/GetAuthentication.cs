namespace APIBingo.Services.ClaimsToken
{
    public class GetAuthentication : IGetAuthentication
    {
        private readonly HttpContext _httpContext;


        public GetAuthentication(HttpContext httpContext) => _httpContext = httpContext;


        public bool ValidateAuthentication()
        {
            return _httpContext.User.Identity != null && _httpContext.User.Identity.IsAuthenticated;
        }
    }
}
