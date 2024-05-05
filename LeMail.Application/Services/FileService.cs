using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace LeMail.Application.Services;

public class FileService : IFileService
{
    public async Task<bool> CreateFileAsync(IFormFile file, string path)
    {
        await using var stream = new FileStream(path, FileMode.Create);
        
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        await file.CopyToAsync(stream);
        return true;
    }

    public async Task<bool> DeleteFileAsync(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }

        File.Delete(path);
        return true;
    }

    public async Task<IFormFile> GetFileAsync(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        var fileStream = File.OpenRead(path);
        
        var file = new FormFile(fileStream, 0, fileStream.Length, null, Path.GetFileName(path))
        {
            Headers = new HeaderDictionary(),
            ContentType = "application/octet-stream"
        };
        
        return file;
    }
}