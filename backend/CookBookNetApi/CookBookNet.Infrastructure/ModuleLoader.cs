using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using CookBookNet.Domain;
using CookBookNet.Infrastructure.DA.Context;
using CookBookNet.Infrastructure.Authentication.PasswordEncryption;
using CookBookNet.Infrastructure.Authentication;
using CookBookNet.Infrastructure.Authentication.TokenIssuer;
using CookBookNet.Domain.Interfaces;
using CookBookNet.Infrastructure.DA.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure
{
    public static class ModuleLoader
    {
        public static void Load(IConfiguration configuration, IServiceCollection services)
        {
            var domainModule = new DefaultDomainLoader();

            domainModule.Configure(configuration, services);

            services.AddScoped<IPasswordEncryptionProvider, PasswordEncryptionProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenIssuer, JWTTokenIssuer>();

            services.AddScoped<IRepository<Recipe>, RecipeRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = (context) =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void LoadContext(IConfiguration configuration, IServiceCollection services)
        {
            bool.TryParse(configuration.GetSection("IsInMemoryDb").Value, out var result);

            if (result)
                services.AddDbContext<CookBookMockDbContext>();
            else
                services.AddDbContext<CookBookDbContext>();
        }
    }
}
