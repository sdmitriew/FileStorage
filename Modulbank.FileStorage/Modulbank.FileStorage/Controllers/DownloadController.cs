using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modulbank.FileStorage.BL.Files.Handlers;
using Modulbank.FileStorage.Dto.Request;

namespace Modulbank.FileStorage.Controllers
{
    [Route("api/downloads")]
    public class DownloadController : Controller
    {
        [HttpGet("{fileId}")]
        public async Task<HttpResponseMessage> Get(Guid fileId, [FromServices] GetFileHandler fh)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var (stream, file) = await fh.Get(fileId);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
            return result;
        }

        [HttpPost("{serviceName}")]
        public async Task<IActionResult> SaveFile([FromForm]IFormFile file, [FromForm]MetaDataRequest model,
            [FromServices] AddFileHandler fh, string serviceName)
        {
            if (file == null) return BadRequest();
            using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                await fh.Save(fileStream, model, file.FileName, file.ContentType, serviceName);
            }
            return Ok();
        }
    }
}
