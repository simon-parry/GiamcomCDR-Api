using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Middleware;
using GiacomCDR_Api.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace GiacomCDR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ApiBaseController
    {
        private readonly IFileService _fileService;
        private string subDirectory = $"\\Data";
        private int count = 0;
        private Int64 totalSize = 0L;

        public UploadFileController(IMediator mediator, IFileService fileService) : base(mediator)
        {
            _fileService = fileService;
        }

        [HttpPost("ImportData")]
        [DisableFormValueModelBinding]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> ImportDataAsync()
        {
            string fileName = await ReadFile();

            var result = CommandAsync(new AddCDRRecordsCSVCommand
            {
                File = fileName
            });

            if ((await result.ConfigureAwait(false)).Result)
            {
                _fileService.RemoveFile(fileName);
                return Ok(new { Count = count, Size = _fileService.SizeConverter(totalSize) });
            }

            return StatusCode(500, "Unable to Import data");
        }

        private async Task<string> ReadFile()
        {
            if (!MultipartRequestManager.IsMultipartContentType(Request.ContentType))
            {
                throw new FormatException("Form without multipart content.");
            }

            var boundary = MultipartRequestManager.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType));

            var reader = new MultipartReader(boundary, HttpContext.Request.Body);

            var section = await reader.ReadNextSectionAsync();
            var fileName = _fileService.GetFilePath(section, subDirectory);
            do
            {
                ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);
                if (!MultipartRequestManager.HasFileContentDisposition(contentDisposition))
                {
                    if (MultipartRequestManager.HasFormDataContentDisposition(contentDisposition) && contentDisposition.Name == nameof(subDirectory))
                    {
                        using var streamReader = new StreamReader(section.Body, Encoding.UTF8);
                        subDirectory = streamReader.ReadToEnd();
                    }

                    section = await reader.ReadNextSectionAsync();
                    continue;
                }
                totalSize += await _fileService.SaveFileAsync(section, subDirectory);

                count++;
                section = await reader.ReadNextSectionAsync();
            } while (section != null);
            return fileName;
        }
    }
}
