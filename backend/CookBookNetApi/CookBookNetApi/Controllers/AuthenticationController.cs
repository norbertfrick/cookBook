using CookBookNet.Infrastructure.Authentication;
using CookBookNet.Infrastructure.Authentication.TokenIssuer;
using CookBookNetApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CookBookNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authService;
        private readonly ITokenIssuer tokenIssuer;

        public AuthenticationController(IAuthenticationService authService, ITokenIssuer tokenIssuer)
        {
            this.authService = authService;
            this.tokenIssuer = tokenIssuer;
        }

       [HttpPost]
       public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto user)
        {
            try
            {
                var authResult = await this.authService.Authenticate(user.Username, user.Password);

                if (authResult == null)
                    return BadRequest(new { message = "Username or password is incorrect!" });

                var token = this.tokenIssuer.GetToken(authResult.Id.ToString());

                return Ok(new
                {
                    Id = authResult.Id,
                    Username = authResult.UserName,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
            
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationDto user)
        {
            var result = this.authService.Register();

            return Ok(result);
        }
    }
}
