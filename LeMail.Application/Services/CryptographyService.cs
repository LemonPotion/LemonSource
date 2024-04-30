using System.Security.Cryptography;
using System.Text;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Validations;

namespace LeMail.Application.Services;

public class CryptographyService : ICryptographyService
{
         public byte[] GenerateKey()
         {
             var rng = RandomNumberGenerator.Create();
             
             var key = new byte[16];
             rng.GetBytes(key);

             return key;
         }

        public  string HashPassword(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100, HashAlgorithmName.SHA256);
            
            var hashBytes = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword, byte[] salt)
        {
            var newHashedPassword = HashPassword(password, salt);
            return newHashedPassword == hashedPassword;
        }

        public string EncryptData(string data, string key)
        {
            if (string.IsNullOrEmpty(data))
                throw new Exception(string.Format(ExceptionMessages.NullError, nameof(data)));
            if (string.IsNullOrEmpty(key))
                throw new Exception(string.Format(ExceptionMessages.NullError, nameof(key)));
            
            var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[aes.BlockSize];
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using var ms = new MemoryStream();
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(dataBytes, 0, dataBytes.Length);
                    cs.FlushFinalBlock();
                }
                
                var encryptedBytes = ms.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string DecryptData(string encryptedData, string key)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new Exception(string.Format(ExceptionMessages.NullError, nameof(encryptedData)));
            if (string.IsNullOrEmpty(key))
                throw new Exception(string.Format(ExceptionMessages.NullError, nameof(key)));


            var encryptedBytes = Convert.FromBase64String(encryptedData);


            using var aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[aes.BlockSize / 8];


            using var decrypt = aes.CreateDecryptor(aes.Key, aes.IV);

            using var ms = new MemoryStream(encryptedBytes);
            using var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
        
}