using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain
{
    public static class DomainModule
    {
        public static void AddDomainModule(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            //services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();
        }
    }
}
