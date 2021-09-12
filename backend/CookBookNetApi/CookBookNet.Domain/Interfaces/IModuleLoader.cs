using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IModuleLoader
    {
        public void Configure(IConfiguration configuration, IServiceCollection services);
    }
}
