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
    public class CataloguesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public CataloguesController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: api/Catalogues
        [HttpGet("GetCatalogues/{id?}/{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetCatalogues(int? id, int startIndex, int pageSize)
        {
            var count = await _context.Catalogues.CountAsync();
            var catalogues = _context.Catalogues//.Include(o => o.articles)
                                                // .Include(c => c.articles)
                                                // .ThenInclude(u => u.metier)
                            .OrderByDescending(o => o.Id)
                            .Skip(startIndex)
                            .Take(pageSize);
            if (id != 0)
            {
                count = await _context.Catalogues.Where(o => o.IdUser == id).CountAsync();
                catalogues = _context.Catalogues//.Include(o => o.articles)
                                                // .Include(c => c.articles)
                                                // .ThenInclude(u => u.metier)
                            .Where(o => o.IdUser == id)
                            .OrderByDescending(o => o.Id)
                            .Skip(startIndex)
                            .Take(pageSize);
            }

            await catalogues.ForEachAsync(catalogue =>
            {
                var article = _context.Articles.Where(a => a.IdCatalogue == catalogue.Id).FirstOrDefault();
                if (article != null)
                    catalogue.articles.Add(article);
            });




            return Ok(new { count = count, List = catalogues });
        }

        // GET: api/Catalogues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalogue = await _context.Catalogues
            .Where(o => o.Id == id)
            .Include(o => o.articles)
            .Include(o => o.user)
            .FirstOrDefaultAsync();


            if (catalogue == null)
            {
                return NotFound();
            }


            // foreach (var item in catalogue.articles)
            // {
            //     item.ImageUrl = ImageService.Get(item.ImageUrl, _hostingEnvironment.WebRootPath);
            // }
            var arts = catalogue.articles.ToList();
            arts.ForEach(a => a.catalogues = null);
            catalogue.articles = arts;
            return Ok(catalogue);
        }

        // PUT: api/Catalogues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogue([FromRoute] int id, [FromBody] Catalogue catalogue)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalogue.Id)
            {
                return BadRequest();
            }


            //_context.Entry(catalogue).State = EntityState.Detached;

            //etapsToDelete
            using (var art = new ArticlesController(_hostingEnvironment, _context))
            {
                //delete
                var articlesOld = _context.Articles.AsNoTracking().Where(i => i.IdCatalogue == id).ToList();
                var articlesToDelete = articlesOld.Where(a => !catalogue.articles.Any(x => x.Id == a.Id)).ToList();
                if (articlesToDelete.Count() > 0)
                {
                    foreach (var item in articlesToDelete)
                    {
                        System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, item.ImageUrl));
                        await art.DeleteArticle(item.Id);
                    }
                }
                //update
                var listToUpdate = catalogue.articles.Where(i => i.Id > 0).ToList();
                if (listToUpdate.Count() > 0)
                {
                    foreach (var item in listToUpdate)
                    {
                        await art.PutArticle(item.Id, item);
                    }
                }
                //add
                var listToAdd = catalogue.articles.Where(i => i.Id <= 0).ToList();
                if (listToAdd.Count() > 0)
                {
                    foreach (var item in listToUpdate)
                    {
                        item.IdCatalogue = id;
                        await art.PostArticle(item);
                    }
                }
            }

            catalogue.articles = null;

            _context.Update(catalogue);

            //_context.UpdateRange(catalogue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Catalogues
        [HttpPost]
        public async Task<IActionResult> PostCatalogue([FromBody] Catalogue catalogue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // foreach (var item in catalogue.articles)
            // {
            //     item.ImageUrl = ImageService.Set(item.Description, item.ImageUrl, _hostingEnvironment.WebRootPath, "Articles");
            // }

            _context.Catalogues.Add(catalogue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogue", new { id = catalogue.Id }, "");
        }

        [HttpPost("postFile")]
        public IActionResult PostImage(/*List<IFormFile> files*/)
        {
            var files = Request.Form.Files;
            string msg = "";
            foreach (var file in files)
            {
                msg += " / " + SaveImage(file);
            }
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

        // DELETE: api/Catalogues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catalogue = await _context.Catalogues.Include(o => o.articles).Where(o => o.Id == id).FirstOrDefaultAsync();
            if (catalogue == null)
            {
                return NotFound();
            }

            foreach (var art in catalogue.articles)
            {
                try
                {
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, art.ImageUrl));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("image delete error = " + ex);
                }

            }
            _context.Articles.RemoveRange(catalogue.articles);
            _context.Catalogues.Remove(catalogue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }



            return Ok();
        }

        private bool CatalogueExists(int id)
        {
            return _context.Catalogues.Any(e => e.Id == id);
        }
    }
}