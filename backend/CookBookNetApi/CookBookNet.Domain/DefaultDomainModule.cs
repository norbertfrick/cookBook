using CookBookNet.Domain.Interfaces;
using CookBookNet.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CookBookNet.Domain
{
    public class DefaultDomainLoader
    {
        public void Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageHandlerService, ImageHandlerService>();
        }
    }
}
