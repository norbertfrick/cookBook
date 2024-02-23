using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Model;
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

        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public TokenProvider(IConfiguration config, IRefreshTokenRepository tokenRepository)
        {
            this._config = config;
            this._refreshTokenRepository = tokenRepository;
        }

        public async Task<string> GenerateRefreshToken(Guid userId)
        {
            var randomNumber = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomNumber);
                try
                {
                    var refreshToken = Convert.ToBase64String(randomNumber);
                    await CreateUserRefreshToken(refreshToken, userId);

                    return refreshToken;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                } 
            }
        }

        public async Task<string> GenerateToken(string refreshToken, Dictionary<string, string> claims)
        {
            if (await IsRefreshTokenExpired(refreshToken))
                return string.Empty;

            var token = await GenerateToken(claims);

            return token;
        }

        public async Task<Guid> GetUserIdByRefreshToken(string refreshToken)
        {
            return (await _refreshTokenRepository.GetByTokenValue(refreshToken)).UserId;
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

        private Task<UserRefreshToken> CreateUserRefreshToken(string tokenString, Guid userId)
        {
            var tokenExpirationInterval = _config.GetValue<int>("Jwt:RefreshTokenExpirationInterval");
            var token = new UserRefreshToken()
            {
                IssuedAt = DateTime.UtcNow,
                IsExpired = false,
                UserId = userId,
                RefreshToken = tokenString,
                ExpiresAt = DateTime.UtcNow.AddMinutes(tokenExpirationInterval),
            };

            return _refreshTokenRepository.Create(token);
        }

        private async Task<bool> IsRefreshTokenExpired(string tokenString)
        {
            var userRefreshToken = await _refreshTokenRepository.GetByTokenValue(tokenString);

            if (userRefreshToken.ExpiresAt > DateTime.UtcNow)
            {
                userRefreshToken.IsExpired = true;
                await _refreshTokenRepository.Update(userRefreshToken.Id, userRefreshToken);
            }

            return userRefreshToken.IsExpired;

        }

        
    }
}
