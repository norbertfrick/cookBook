using Cookbook.Api.Enumerators;
using Cookbook.Api.Interfaces;
using Cookbook.Domain.Extensions;
using Microsoft.OpenApi.Extensions;
using System.ComponentModel;

namespace Cookbook.Api.Services
{
    public class CookieHelperService : ICookieHelperService
    {
        private readonly CookieOptions _defaultCookieOptions;

        public CookieHelperService()
        {
            _defaultCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true
            };
        }

        public HttpContext AddJwtCookie(HttpContext context, string jwtToken)
        {
            RemoveJwtCookie(context);
            context.Response.Cookies.Append(eCookieType.AccessToken.GetDescription(), jwtToken, _defaultCookieOptions);

            return context;
        }

        public HttpContext AddRefreshTokenCookie(HttpContext context, string jwtToken)
        {
            RemoveRefreshTokenCookie(context);
            context.Response.Cookies.Append(eCookieType.RefreshToken.GetDescription(), jwtToken, _defaultCookieOptions);

            return context;
        }

        public string GetJwtTokenFromRequest(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue(eCookieType.AccessToken.GetDescription(), out var token))
                return token;

            return string.Empty;
        }

        public string GetRefreshTokenFromRequest(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue(eCookieType.RefreshToken.GetDescription(), out var token))
                return token;

            return string.Empty;
        }

        public HttpContext RemoveJwtCookie(HttpContext context)
        {
            context.Response.Cookies.Delete(eCookieType.AccessToken.GetDescription());

            return context;
        }

        public HttpContext RemoveRefreshTokenCookie(HttpContext context)
        {
            context.Response.Cookies.Delete(eCookieType.RefreshToken.GetDescription());

            return context;
        }

        
    }
}
