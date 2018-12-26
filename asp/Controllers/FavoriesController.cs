using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Models;
using Microsoft.AspNetCore.Hosting;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;
        //
        public FavoriesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Favories
        [HttpGet("GetFavories/{id}")]
        public async Task<IEnumerable<Favorie>> GetFavories(int id)
        {
            var favories = _context.Favories.Include(o => o.ouvrier.metier)
                                    .Include(o => o.ouvrier)
                                        .ThenInclude(o => o.location)
                                            .ThenInclude(o => o.quartier)
                                                .ThenInclude(o => o.ville)
                            .Where(o => o.IdUser == id);

            // foreach (var fav in l)
            // {
            //     fav.ouvrier.ImageUrl = ImageService.Get(fav.ouvrier.ImageUrl, _hostingEnvironment.WebRootPath);
            // }

            // await favories.ForEachAsync(fav => fav.user.location.users = null);

            return favories;
        }

        //
        [HttpGet("GetState/{IdOuvrier}/{idUser}")]
        public async Task<IActionResult> GetState([FromRoute]  int IdOuvrier, int idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var t = await _context.Favories.FindAsync(IdOuvrier, idUser);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>" + t);
            if (t == null)
            {
                return Ok(0);
            }

            return Ok(1);
        }

        // GET: api/Favories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavorie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favorie = await _context.Favories.FindAsync(id);

            if (favorie == null)
            {
                return NotFound();
            }

            return Ok(favorie);
        }

        // PUT: api/Favories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorie([FromRoute] int id, [FromBody] Favorie favorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorie.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(favorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavorieExists(id))
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

        // POST: api/Favories
        [HttpPost]
        public async Task<IActionResult> PostFavorie([FromBody] Favorie favorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Favories.Add(favorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavorieExists(favorie.IdUser))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavorie", new { id = favorie.IdUser }, favorie);
        }

        // DELETE: api/Favories/5
        [HttpDelete("DeleteFavorie/{IdOuvrier}/{idUser}")]
        public async Task<IActionResult> DeleteFavorie([FromRoute] int IdOuvrier, int idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var favorie = await _context.Favories.FindAsync(idUser, IdOuvrier);
            if (favorie == null)
            {
                return NotFound();
            }

            _context.Favories.Remove(favorie);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool FavorieExists(int id)
        {
            return _context.Favories.Any(e => e.IdUser == id);
        }
    }
}