using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ezBuy.Business.Layer.Services.Custom
{
    public class EncryptPassService
    {
        const int _keySize = 64;
        const int _iterations = 350000;
        HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

        public EncryptPassService() { }

        public string Encrypt(string userRegisterPassword)
            => HashPassword(userRegisterPassword, out var salt);

        private string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(_keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _iterations,
                _hashAlgorithm,
                _keySize);
            return Convert.ToHexString(hash);
        }

        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

    }
}
