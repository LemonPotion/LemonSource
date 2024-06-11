using Microsoft.AspNetCore.Http;

namespace LeMail.Application.Interfaces.Services;

public interface IFileService
{
    Task<bool> CreateFileAsync(IFormFile file, string path);
    
    Task<bool> DeleteFileAsync(string path);
    
    Task<IFormFile> GetFileAsync(string path);
}