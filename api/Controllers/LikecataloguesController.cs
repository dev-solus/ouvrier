//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Models;
//using Microsoft.AspNetCore.SignalR;
//using asp.Dtos;
//using asp.SignalR;

//namespace asp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LikecataloguesController : ControllerBase
//    {
//        private readonly MyContext _context;
//        private IHubContext<Like, ILikeHubClient> _hubContext;

//        public LikecataloguesController(MyContext context, IHubContext<Like, ILikeHubClient> hubContext)
//        {
//            _context = context;
//            _hubContext = hubContext;
//        }

//        // GET: api/Likecatalogues
//        [HttpGet("GetLikecatalogues/{idUser}/{idCatalogue}")]
//        public async Task<IActionResult> GetLikecatalogues(int idUser, int idCatalogue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var t = await _context.Likecatalogues.FindAsync(idUser, idCatalogue);

//            if (t == null)
//            {
//                return Ok(0);
//            }

//            return Ok(1);
//        }

//        // GET: api/Likecatalogues/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetLikecatalogue([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            int t = await _context.Likecatalogues.Where(m => m.IdCatalogue == id).CountAsync();

//            return Ok(t);
//        }

//        // PUT: api/Likecatalogues/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLikecatalogue([FromRoute] int id, [FromBody] Likecatalogue likecatalogue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != likecatalogue.IdUser)
//            {
//                return BadRequest();
//            }

//            _context.Entry(likecatalogue).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!LikecatalogueExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Likecatalogues
//        [HttpPost]
//        public async Task<IActionResult> PostLikecatalogue([FromBody] Likecatalogue likecatalogue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Likecatalogues.Add(likecatalogue);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (LikecatalogueExists(likecatalogue.IdUser))
//                {
//                    return new StatusCodeResult(StatusCodes.Status409Conflict);
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            //return CreatedAtAction("GetLikecatalogue", new { id = likecatalogue.IdUser }, likecatalogue);
//            await _hubContext.Clients.All.BroadcastLike(likecatalogue.IdCatalogue);
//            return Ok();
//        }

//        // DELETE: api/Likecatalogues/5
//        [HttpDelete("{idUser}/{idCatalogue}")]
//        public async Task<IActionResult> DeleteLikecatalogue([FromRoute] int idUser, int idCatalogue)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var likecatalogue = await _context.Likeusers.FindAsync(idUser, IdOuvrier);
//            if (likecatalogue == null)
//            {
//                return NotFound();
//            }

//            _context.Likecatalogues.Remove(likecatalogue);
//            await _context.SaveChangesAsync();

//            //return Ok(likecatalogue);
//            await _hubContext.Clients.All.DeleteLike(idCatalogue);
//            return Ok();
//        }

//        private bool LikecatalogueExists(int id)
//        {
//            return _context.Likecatalogues.Any(e => e.IdUser == id);
//        }
//    }
//}