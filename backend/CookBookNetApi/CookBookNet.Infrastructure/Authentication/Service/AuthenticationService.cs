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

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = this.repository.GetAll().Where(u => u.UserName == username).FirstOrDefault();

            if (user == null)
                return null;

            if (!this.encryptionProvider.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public Task<User> ChangePassword()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(string email, string username, string password)
        {
            var user = new User();
            user.UserName = username;
            user.Email = email;

            this.encryptionProvider.CreatePasswordHash(password, out var hash, out var key);

            user.PasswordHash = hash;
            user.PasswordSalt = key;

            //var hashString = Encoding.UTF8.GetString(hash, 0, hash.Length);
            //var saltString = Encoding.UTF8.GetString(key, 0, key.Length);


            var result = await this.repository.Create(user);

            return result;
        }
    }
}
