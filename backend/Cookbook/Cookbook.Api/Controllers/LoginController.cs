using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cookbook.Api.Helpers;
using Cookbook.Api.Interfaces;
using Cookbook.Domain.Helpers;
using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Model;
using Cookbook.Domain.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Api.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private readonly ICookieHelperService _cookieHelper;

        public LoginController(ILoginService login, ICookieHelperService cookieHelper)
        {
            this._loginService = login;
            this._cookieHelper = cookieHelper;
        }


        [Route("/login")]
        public async Task<ActionResult<RequestResponse<TokenWrapper>>> Login([FromBody] string email, string password)
        {
            var result = await _loginService.Login(email, password);

            if (result.IsSuccess)
            {
                _cookieHelper.AddJwtCookie(HttpContext, result.Data.AccessToken);
                _cookieHelper.AddRefreshTokenCookie(HttpContext, result.Data.RefreshToken);
            }

            return new RequestResponse<TokenWrapper>(result.IsSuccess, result.Data, result.Message);
        }

        [Authorize]
        [Route("/logout")]
        public async Task<ActionResult<RequestResponse>> Logout([FromBody] Guid userId)
        {
            var result = await _loginService.Logout(userId);

            if (result.IsSuccess)
            {
                _cookieHelper.RemoveJwtCookie(HttpContext);
                _cookieHelper.RemoveRefreshTokenCookie(HttpContext);
            }

            return result.ToRequestResponse();
        }

        [Route("/register")]
        public async Task<ActionResult<RequestResponse<UserProfile>>> Register(string username, string password)
            => (await _loginService.RegisterUser(username, password)).ToRequestResponse();

        public async Task<ActionResult<RequestResponse<TokenWrapper>>> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _loginService.RefreshToken(refreshToken);

            if (result.IsSuccess)
            {
                _cookieHelper.AddJwtCookie(HttpContext, result.Data.AccessToken);
                _cookieHelper.AddRefreshTokenCookie(HttpContext, result.Data.RefreshToken);
            }

            return result.ToRequestResponse();
        }
    }
}