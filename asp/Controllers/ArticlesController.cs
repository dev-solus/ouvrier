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

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public ArticlesController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: api/Articles
        [HttpGet("GetArticles/{id?}")]
        public async Task<IEnumerable<Article>> GetArticles(int id)
        {
            var articles = _context.Articles.Where(o => o.IdCatalogue == id);
            // foreach (var art in arts)
            // {
            //     art.ImageUrl = ImageService.Get(art.ImageUrl, _hostingEnvironment.WebRootPath);
            // }

            await articles.ForEachAsync(a => a.catalogues = null);

            return articles;
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
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
            // article.ImageUrl = ImageService.Set(article.Description, article.ImageUrl, _hostingEnvironment.WebRootPath, "Articles");
            // var oldArticle = await _context.Articles.FindAsync(id);
            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("postFile")]
        public IActionResult PostImage(IFormFile file)
        {
            string msg = SaveImage(file);
            return Ok(new { msg = msg });
        }

        string SaveImage(IFormFile file)
        {
            try
            {
                // var file = Request.Form.Files[0];  
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "Catalogues");
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

        // POST: api/Articles
        [HttpPost]
        public async Task<IActionResult> PostArticle([FromBody]  Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            // ImageService.Delete(_hostingEnvironment.WebRootPath, article.ImageUrl);
            return Ok(article);
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}