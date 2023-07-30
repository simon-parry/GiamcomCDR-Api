using Microsoft.AspNetCore.WebUtilities;

namespace GiacomCDR_Api.Services
{
    public interface IFileService
    {
        Task<long> SaveFileAsync(MultipartSection section, string subDirectory);
        string SizeConverter(long bytes);
        string GetFilePath(MultipartSection section, string subDirectory);
        void RemoveFile(string subDirectory);
    }
}
