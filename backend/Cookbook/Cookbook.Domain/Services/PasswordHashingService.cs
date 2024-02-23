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
        private readonly HashAlgorithmName _algorithmName = HashAlgorithmName.SHA3_512;
        private const int _keySize = 64;

        public bool IsPasswordValid(string password, string hash, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, Encoding.UTF8.GetBytes(salt), _iterations, _algorithmName, _keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        public (string password, string salt) HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(32);
            var iteration = 350000;
            var hashAlgorithm = HashAlgorithmName.SHA3_512;
            var keySize = 64;

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iteration, hashAlgorithm, keySize);

            return (Convert.ToHexString(hash), Convert.ToBase64String(salt));
        }


    }
}
