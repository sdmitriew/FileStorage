using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modulbank.FileStorage.BL.Files.Handlers;

namespace Modulbank.FileStorage.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("{fileId}")]
        public async Task<IActionResult> Get(Guid fileId, [FromServices] GetFileHandler fh)
        {
            var (stream, file) = await fh.Get(fileId);
            return File(stream, file.ContentType, file.FileName);
        }
    }
}
