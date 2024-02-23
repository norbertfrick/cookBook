namespace Cookbook.Api.Interfaces
{
    public interface ICookieHelperService
    {
        public HttpContext AddJwtCookie(HttpContext context, string jwtToken);

        public HttpContext RemoveJwtCookie(HttpContext context);

        public HttpContext AddRefreshTokenCookie(HttpContext context, string jwtToken);

        public HttpContext RemoveRefreshTokenCookie(HttpContext context);

        public string GetRefreshTokenFromRequest(HttpContext context);

        public string GetJwtTokenFromRequest(HttpContext context);
    }
}
