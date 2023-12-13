using Microsoft.AspNetCore.Http;

namespace Olx.Application.Interfaces.Files;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);
}
