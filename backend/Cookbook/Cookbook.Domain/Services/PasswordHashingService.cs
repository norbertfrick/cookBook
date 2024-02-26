using Cookbook.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        private const int _iterations = 350000;
        private readonly HashAlgorithmName _algorithmName = HashAlgorithmName.SHA1;
        private const int _keySize = 64;

        public bool IsPasswordValid(string password, string hash, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromBase64String(salt), _iterations, _algorithmName, _keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromBase64String(hash));
        }

        public (string password, string salt) HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(32);
            var iteration = _iterations;
            var hashAlgorithm = _algorithmName;
            var keySize = _keySize;

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iteration, hashAlgorithm, keySize);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }


    }
}
