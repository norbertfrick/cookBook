using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CookBookNet.Domain;

namespace CookBookNet.Infrastructure
{
    public static class ModuleLoader
    {
        public static void Load(IConfiguration configuration, IServiceCollection services)
        {
            var domainModule = new DefaultDomainLoader();

            domainModule.Configure(configuration, services);
        }
    }
}
