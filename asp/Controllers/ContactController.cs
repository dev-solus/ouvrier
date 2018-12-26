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
    public class ContactController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public ContactController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<Contact> Get()
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files", "about.json");
            // var path = "wwwroot/Keys/Keys.json";

            var result = new Contact();

            if (System.IO.File.Exists(path))
            {
                var initialJson = await System.IO.File.ReadAllTextAsync(path);
                result = JsonConvert.DeserializeObject<Contact>(initialJson);
            }

            return result;
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact about)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle([FromRoute] int id, [FromBody] Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }
            
            

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            // ImageService.Delete(_hostingEnvironment.WebRootPath, article.ImageUrl);
            return Ok("article");
        }

        [HttpPost("postFile")]
        public IActionResult PostImage(/*List<IFormFile> files*/)
        {
            var file = Request.Form.Files[0];
            string msg =  SaveImage(file);
            return Ok(new { msg = msg });
        }

        string SaveImage(IFormFile file)
        {
            try
            {
                // var file = Request.Form.Files[0];  
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (file.Length > 0)
                {
                    string fullPath = Path.Combine(path, file.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return file.FileName;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

    }

    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DiscriptionHTML { get; set; }
        public string ImageUrl { get; set; }
    }
}