using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration config)
        {
            var dbConnectionString = config.GetConnectionString("CookbookDb");
            services.AddDbContext<CookbookDbContext>(options => options.UseSqlServer(dbConnectionString, x => x.MigrationsAssembly("Cookbook.Infrastructure")));

            //services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}