using Cookbook.Api.Enumerators;
using Cookbook.Api.Interfaces;
using Cookbook.Api.Services;
using Cookbook.Domain.Extensions;
using Cookbook.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cookbook.Api
{
    public static class ApiModule
    {
        public static void AddApiModule(this IServiceCollection services)
        {
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<ICookieHelperService, CookieHelperService>();
        }

        public static void AddCookbookAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtIssuer = config.GetSection("Jwt:Issuer").Value;
            var jwtKey = config.GetSection("Jwt:Secret").Value;

            services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
                options.Events.OnMessageReceived = context =>
                {
                    if (context.Request.Cookies.ContainsKey(eCookieType.AccessToken.GetDescription()))
                        context.Token = context.Request.Cookies[eCookieType.AccessToken.GetDescription()];

                    return Task.CompletedTask;
                };
            });
        }
    }
}
