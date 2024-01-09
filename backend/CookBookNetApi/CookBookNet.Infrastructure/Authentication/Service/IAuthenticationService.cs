using CookBookNet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.Authentication
{
    public interface IAuthenticationService
    {
        public Task<User> Authenticate(string username, string password);

        public Task<User> Register(string email, string username, string password);

        public Task<User> ChangePassword();
    }
}
