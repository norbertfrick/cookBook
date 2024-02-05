using Cookbook.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Cookbook.Api.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _config;

        public TokenProvider(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<string> GenerateToken(Dictionary<string, string> claims)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_config["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(this.CreateClaims(claims)),
                Expires = DateTime.Now.AddMinutes(_config.GetValue<int>("Jwt:ExpirationInterval")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config.GetValue<string>("Jwt:Issuer"),
                IssuedAt = DateTime.UtcNow,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    private List<Claim> CreateClaims(Dictionary<string, string> claimsDict)
    {
        var claims = new List<Claim>();

        foreach (var claim in claimsDict)
            claims.Add(new Claim(claim.Key, claim.Value));

        return claims;
    }
}
}
