using ezbuy.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ezbuy.Services
{
    public class EncryptPassService : IEncryptPassService
    {
        private const int _keySize = 64;
        private const int _iterations = 350000;
        private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

        public EncryptPassService() { }

        public string Encrypt(string userRegisterPassword)
            => HashPassword(userRegisterPassword);

        private string HashPassword(string password)
            => CalcularHash(password);

        public bool VerifyPassword(string pass, string hashDb)
        { 
            string hashCalculated = CalcularHash(pass); 
            return hashCalculated.Equals(hashDb);
        }

        private string CalcularHash(string pass)
        { 
            var hashAlgorithm = HashAlgorithm.Create(HashAlgorithmName.SHA256.ToString()); 
            var passwordBytes = Encoding.UTF8.GetBytes(pass); 
            var hashBytes = hashAlgorithm?.ComputeHash(passwordBytes); 
            var computedHash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return computedHash;
        }  
    }
}
