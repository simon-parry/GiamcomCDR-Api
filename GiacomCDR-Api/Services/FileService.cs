using Microsoft.AspNetCore.WebUtilities;

namespace GiacomCDR_Api.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
            
        }

        public async Task<long> SaveFileAsync(MultipartSection section, string subDirectory)
        {
            Directory.CreateDirectory(subDirectory);

            var filePath = GetFilePath(section, subDirectory);
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            var fileSection = section.AsFileSection();

            await fileSection.FileStream.CopyToAsync(stream);

            return fileSection.FileStream.Length;
        }

        public string GetFilePath(MultipartSection section, string subDirectory)
        {
            var fileSection = section.AsFileSection();

            var filePath = Path.Combine(subDirectory, fileSection.FileName);

            return filePath;
        }

        public void RemoveFile(string subDirectory) 
        { 
            File.Delete(subDirectory);
        }

        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}
