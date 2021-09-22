using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.Authentication.TokenIssuer
{
    public interface ITokenIssuer
    {
        public string GetToken(string userId);
    }
}
