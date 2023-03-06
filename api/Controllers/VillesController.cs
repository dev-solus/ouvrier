using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillesController : ControllerBase
    {
        private readonly MyContext _context;
        public VillesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Villes
        [HttpGet]
        public IEnumerable<Ville> GetVilles()
        {
            return _context.Villes;
        }

        // GET: api/Villes
        [HttpGet("GetFive/{colToSort}/{orderBy}/{startIndex}/{pageSize}")]
        public IActionResult GetFive(string colToSort, string orderBy, int startIndex, int pageSize)
        {
            string s = $"select * from villes order by {colToSort} {orderBy}";
            string s2 = $"select * from villes order by {colToSort} {orderBy} LIMIT {pageSize} OFFSET {startIndex}";
            //
            //
            var l = _context.Villes.FromSqlRaw(s).Skip(startIndex).Take(pageSize).ToList();
            return Ok(new { count = _context.Villes.Count(), List = l });
        }

        // GET: api/Villes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVille([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ville = await _context.Villes.FindAsync(id);

            if (ville == null)
            {
                return NotFound();
            }

            return Ok(ville);
        }

        // PUT: api/Villes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVille([FromRoute] int id, [FromBody] Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ville.Id)
            {
                return BadRequest();
            }

            _context.Entry(ville).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilleExists(id))
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

        // POST: api/Villes
        [HttpPost]
        public async Task<IActionResult> PostVille([FromBody] Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Villes.Add(ville);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVille", new { id = ville.Id }, ville);
        }

        // DELETE: api/Villes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVille([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ville = await _context.Villes.FindAsync(id);
            if (ville == null)
            {
                return NotFound();
            }

            _context.Villes.Remove(ville);
            await _context.SaveChangesAsync();

            return Ok(ville);
        }

        private bool VilleExists(int id)
        {
            return _context.Villes.Any(e => e.Id == id);
        }
    }
}