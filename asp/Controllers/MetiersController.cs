using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Models;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetiersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MetiersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Metiers
        [HttpGet]
        public IEnumerable<Metier> GetMetiers()
        {
            return _context.Metiers;
        }

        [HttpGet("GetAll/{colToSort}/{orderBy}/{startIndex}/{pageSize}")]
        public IActionResult GetMetiers(string colToSort, string orderBy, int startIndex, int pageSize)
        {
            string s = $"select * from metiers order by {colToSort} {orderBy}";
            var l = _context.Metiers.FromSql(s).Skip(startIndex).Take(pageSize).ToList();
            return Ok(new { count = _context.Metiers.Count(), List = l });
        }

        // GET: api/Metiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMetier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metier = await _context.Metiers.FindAsync(id);

            if (metier == null)
            {
                return NotFound();
            }

            return Ok(metier);
        }

        // PUT: api/Metiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetier([FromRoute] int id, [FromBody] Metier metier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metier.Id)
            {
                return BadRequest();
            }

            _context.Entry(metier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetierExists(id))
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

        // POST: api/Metiers
        [HttpPost]
        public async Task<IActionResult> PostMetier([FromBody] Metier metier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Metiers.Add(metier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetier", new { id = metier.Id }, metier);
        }

        // DELETE: api/Metiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metier = await _context.Metiers.FindAsync(id);
            if (metier == null)
            {
                return NotFound();
            }

            _context.Metiers.Remove(metier);
            await _context.SaveChangesAsync();

            return Ok(metier);
        }

        private bool MetierExists(int id)
        {
            return _context.Metiers.Any(e => e.Id == id);
        }
    }
}