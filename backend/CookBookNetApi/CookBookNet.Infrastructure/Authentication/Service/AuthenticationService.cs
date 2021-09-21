using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using CookBookNet.Infrastructure.Authentication.PasswordEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> repository;
        private readonly IPasswordEncryptionProvider encryptionProvider;

        public AuthenticationService(IRepository<User> repository, IPasswordEncryptionProvider encryptionProvider)
        {
            this.repository = repository;
            this.encryptionProvider = encryptionProvider;
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User ChangePassword()
        {
            throw new NotImplementedException();
        }

        public User Register()
        {
            throw new NotImplementedException();
        }
    }
}
