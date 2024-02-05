using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Api.Helpers;
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

        public LoginController(ILoginService login)
        {
            this._loginService = login;
        }


        [Route("/login")]
        public async Task<ActionResult<RequestResponse<TokenWrapper>>> Login([FromBody] string email, string password)
        {
            var result = await _loginService.Login(email, password);

            if (result.IsSuccess)
                AddJwtToCookies(result.Data.AccessToken);

            return new RequestResponse<TokenWrapper>(result.IsSuccess, result.Data, result.Message);
        }

        [Authorize]
        [Route("/logout")]
        public async Task<ActionResult<RequestResponse>> Logout([FromBody] Guid userId) 
        {
            var result = await _loginService.Logout(userId);

            if (result.IsSuccess)
                RemoveJWTFromCookies();

            return result.ToRequestResponse();
        }

        public void RemoveJWTFromCookies()
        {
            
        }

        public void AddJwtToCookies(string token)
        {

        }
    }
}