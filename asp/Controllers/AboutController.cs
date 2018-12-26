using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public AboutController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Abouts
        [HttpGet]
        public async Task<About> Get()
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files", "about.json");
            // var path = "wwwroot/Keys/Keys.json";

            var result = new About();

            if (System.IO.File.Exists(path))
            {
                var initialJson = await System.IO.File.ReadAllTextAsync(path);
                result = JsonConvert.DeserializeObject<About>(initialJson);
            }

            return result;
        }

        // POST: api/Abouts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] About about)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fullPath = Path.Combine(path, "about.json");

                var json = JsonConvert.SerializeObject(about);

                await System.IO.File.WriteAllTextAsync(fullPath, json);

            }
            catch (System.Exception ex)
            {
                return Ok(new { file = ex });
            }

            return Ok(new { file = about });
        }

    }

    public class About
    {
        public string AboutHTML;
    }
}