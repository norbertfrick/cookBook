using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Wrappers
{
    public class TokenWrapper
    {
        public TokenWrapper(string accessToken, string refreshToken, Guid userId) 
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.UserId = userId;
        }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public Guid UserId { get; set; }
    }
}
