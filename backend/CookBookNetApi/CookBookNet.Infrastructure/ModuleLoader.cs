using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CookBookNet.Domain;
using CookBookNet.Infrastructure.DA.Context;

namespace CookBookNet.Infrastructure
{
    public static class ModuleLoader
    {
        public static void Load(IConfiguration configuration, IServiceCollection services)
        {
            var domainModule = new DefaultDomainLoader();

            domainModule.Configure(configuration, services);

            LoadContext(configuration, services);
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
