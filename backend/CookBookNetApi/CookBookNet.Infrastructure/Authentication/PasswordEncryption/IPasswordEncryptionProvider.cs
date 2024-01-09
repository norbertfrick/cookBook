using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.Authentication.PasswordEncryption
{
    public interface IPasswordEncryptionProvider
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
