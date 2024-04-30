namespace LeMail.Application.Interfaces.Services;

public interface ICryptographyService
{
    byte[] GenerateKey();
    string HashPassword(string password, byte[] salt);
    
    bool VerifyPassword(string password, string hashedPassword, byte[] salt);

    string EncryptData(string data, string key);
    string DecryptData(string encryptedData, string key);
}