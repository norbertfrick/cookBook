using CookBookNet.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CookBookNet.Domain
{
    public class DefaultDomainLoader : IModuleLoader
    {
        public void Configure(IConfiguration configuration, IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }
    }
}
