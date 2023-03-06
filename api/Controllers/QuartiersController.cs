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
    public class QuartiersController : ControllerBase
    {
        private readonly MyContext _context;
        public QuartiersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Quartiers
        [HttpGet("GetQuartiers/{idVille}")]
        public IEnumerable<Quartier> GetQuartiers(int idVille)
        {
            if (idVille == 0)
            {
                return _context.Quartiers;
            }
            return _context.Quartiers.Where(o => o.IdVille == idVille);
        }

        // GET: api/Villes
        [HttpGet("GetFive/{colToSort}/{orderBy}/{startIndex}/{pageSize}")]
        public IActionResult GetFive(string colToSort, string orderBy, int startIndex, int pageSize)
        {
            string s = "select q.id, q.nom, v.nom as 'ville' " +
                        "from quartiers q " +
                            " join villes v on v.id = q.idVille " +
                        $"order by {colToSort} {orderBy}";
            //
            string s2 = $"select * from quartiers order by {colToSort} {orderBy}";
            //

            //var o1 = _context.Database.SqlQuery("");

            //var t = SqlQueryHelper.Execute2(_context, s);
           

            var l = _context.Quartiers
                .Select(o => new { o.Id, o.Nom, ville = o.ville.Nom })//.FromSql(s2)
                                                                                  //.OrderBy(a => new { colToSort })
                .Skip(startIndex).Take(pageSize)
                .ToList();
            //var list = _mapper.Map<IEnumerable<QuartierDto>>(l);
            return Ok(new { count = _context.Quartiers.Count(), List = l });
        }



        // GET: api/Quartiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuartier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quartier = await _context.Quartiers.FindAsync(id);

            if (quartier == null)
            {
                return NotFound();
            }

            return Ok(quartier);
        }

        // PUT: api/Quartiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuartier([FromRoute] int id, [FromBody] Quartier quartier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quartier.Id)
            {
                return BadRequest();
            }

            _context.Entry(quartier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartierExists(id))
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

        // POST: api/Quartiers
        [HttpPost]
        public async Task<IActionResult> PostQuartier([FromBody] Quartier quartier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quartiers.Add(quartier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuartier", new { id = quartier.Id }, quartier);
        }

        // DELETE: api/Quartiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuartier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quartier = await _context.Quartiers.FindAsync(id);
            if (quartier == null)
            {
                return NotFound();
            }

            _context.Quartiers.Remove(quartier);
            await _context.SaveChangesAsync();

            return Ok(quartier);
        }

        private bool QuartierExists(int id)
        {
            return _context.Quartiers.Any(e => e.Id == id);
        }
    }
}