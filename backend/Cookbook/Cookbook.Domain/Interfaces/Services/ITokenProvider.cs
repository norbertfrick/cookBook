using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Services
{
    public interface ITokenProvider
    {
        public Task<string> GenerateToken(Dictionary<string, string> claims);

        public Task<string> GenerateRefreshToken();

    }
}
