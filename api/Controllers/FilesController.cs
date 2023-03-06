using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Services;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // private IWebHostEnvironment _hostingEnvironment;
        private readonly AppSettings _appSettings;
        private readonly string _webRootPath;
        public FilesController(IWebHostEnvironment hostingEnvironment, IOptions<AppSettings> appSettings)
        {
            // _hostingEnvironment = hostingEnvironment;
            _appSettings = appSettings.Value;
            // if(_appSettings.deployMode=="DOCKER")
            //     _webRootPath = "C:\\Users\\Administrator\\Documents\\APP\\GAM\\PIC";
            // else
            // _webRootPath = _appSettings.UrlUpload == "" ? hostingEnvironment.WebRootPath : _appSettings.UrlUpload;
            _webRootPath = hostingEnvironment.WebRootPath ?? "wwwroot";

        }

        [HttpPost("{folder}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile([FromRoute] string folder)
        {
            var file = Request.Form.Files[0];

            string path = Path.Combine(_webRootPath, folder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (file != null)
            {
                try
                {
                    string fullPath = Path.Combine(path, file.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (System.Exception ex)
                {
                    return Ok(ex.Message);
                }

            }
            return Ok(new { message = file.FileName });
        }

        [HttpPost("{folder}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles([FromRoute] string folder)
        {
            IFormFileCollection files = Request.Form.Files;

            if (files.Count == 0)
            {
                return Ok();
            }

            folder = folder.Contains("_") ? folder.Replace("_", "/") : folder;

            string path = Path.Combine(_webRootPath, folder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (files.Count > 0)
            {
                try
                {
                    foreach (var file in files)
                    {
                        string fullPath = Path.Combine(path, file.FileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    return Ok(ex.Message);
                }

            }
            return Ok();
        }

        [HttpPost("{folder}")]
        public IActionResult DeleteFiles(string folder, List<string> filenames)
        {
            if (filenames.Count == 0)
            {
                return Ok(false);
            }
            try
            {
                foreach (var filename in filenames)
                {
                    folder = folder.Contains("_") ? folder.Replace("_", "/") : folder;
                    var fileInfo = new FileInfo($"{_webRootPath}\\{folder}\\{filename}");
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                }

            }
            catch (System.Exception ex)
            {
                return Ok(ex.Message);
            }

            return Ok(true);
        }

        [HttpPost("{folder}/{filename}")]
        public IActionResult DeleteFile(string folder, string filename)
        {
            if (filename == null)
            {
                return Ok(false);
            }

            var fileInfo = new FileInfo($"{_webRootPath ?? "wwwroot"}\\{folder}\\{filename.Replace("_", "/")}");

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
