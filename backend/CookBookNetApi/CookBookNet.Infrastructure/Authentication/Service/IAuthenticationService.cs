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
        public User Authenticate(string username, string password);

        public User Register();

        public User ChangePassword();
    }
}
