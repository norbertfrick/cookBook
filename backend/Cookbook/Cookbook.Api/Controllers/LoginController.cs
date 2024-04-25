using Cookbook.Api.Helpers;
using Cookbook.Api.Interfaces;
using Cookbook.Api.Requests;
using Cookbook.Domain.Helpers;
using Cookbook.Domain.Interfaces;
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
        [HttpPost]
        public async Task<ActionResult<RequestResponse<TokenWrapper>>> Login([FromBody] RegisterLoginUserRequest request)
        {
            var result = await _loginService.Login(request.Username, request.Password);

            if (result.IsSuccess)
            {
                _cookieHelper.AddJwtCookie(HttpContext, result.Data.AccessToken);
                _cookieHelper.AddRefreshTokenCookie(HttpContext, result.Data.RefreshToken);
            }

            return new RequestResponse<TokenWrapper>(result.IsSuccess, result.Data, result.Message);
        }

        [Authorize]
        [Route("/logout")]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Logout([FromBody] Guid userId)
        {
            var result = await _loginService.Logout(userId, _cookieHelper.GetRefreshTokenFromRequest(HttpContext));

            if (result.IsSuccess)
            {
                _cookieHelper.RemoveJwtCookie(HttpContext);
                _cookieHelper.RemoveRefreshTokenCookie(HttpContext);
            }

            return result.ToRequestResponse();
        }

        [Route("/register")]
        [HttpPost]
        public async Task<ActionResult<RequestResponse<Nullable<Guid>>>> Register([FromBody] RegisterLoginUserRequest request)
            => (await _loginService.RegisterUser(request.Username, request.Password)).ToRequestResponse();

        [Route("/refresh")]
        [HttpPost]
        public async Task<ActionResult<RequestResponse<TokenWrapper>>> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _loginService.RefreshToken(_cookieHelper.GetRefreshTokenFromRequest(HttpContext));

            if (result.IsSuccess)
            {
                _cookieHelper.AddJwtCookie(HttpContext, result.Data.AccessToken);
                _cookieHelper.AddRefreshTokenCookie(HttpContext, result.Data.RefreshToken);
            }

            return result.ToRequestResponse();
        }

        [Route("/isloggedin")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<bool>> IsLoggedIn()
        {
            return true;
        }

    }
}