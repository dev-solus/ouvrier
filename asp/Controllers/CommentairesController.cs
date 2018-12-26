using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Models;
using Microsoft.AspNetCore.SignalR;
using asp.SignalR;
using Microsoft.AspNetCore.Hosting;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IHubContext<CommentHub, ICommentHubClient> _hubContext;
        private IHubContext<CountComment, ICommentCountClient> _hubContext2;
        private IHostingEnvironment _hostingEnvironment;
        //
        public CommentairesController(
            ApplicationDbContext context,
            IHubContext<CommentHub, ICommentHubClient> hubContext,
            IHubContext<CountComment, ICommentCountClient> hubContext2,
            IHostingEnvironment hostingEnvironment
            )
        {
            _context = context;
            _hubContext = hubContext;
            _hubContext2 = hubContext2;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Commentaires
        [HttpGet("GetCommentaires/{id}")]
        public async Task<IEnumerable<Commentaire>> GetCommentaires(int id)
        {
            var comments = await _context.Commentaires.Where(o => o.IdOuvrier == id).Include(o => o.user).ToListAsync();
            // foreach (var item in comments)
            // {
            //     item.user.ImageUrl = ImageService.Get(item.user.ImageUrl, _hostingEnvironment.WebRootPath);
            // }
            return comments;
        }

        // GET: api/Commentaires/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentaire([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentaire = await _context.Commentaires.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return Ok(commentaire);
        }

        // PUT: api/Commentaires/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaire([FromRoute] int id, [FromBody] Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _hubContext.Clients.All.EditComment(commentaire.Id, commentaire);
            return NoContent();
        }

        // POST: api/Commentaires
        [HttpPost]
        public async Task<IActionResult> PostCommentaire([FromBody] Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var c = commentaire;
            var user = commentaire.user;
            commentaire.user = null;
            _context.Commentaires.Add(commentaire);
            try
            {
                await _context.SaveChangesAsync();
                // commentaire.user = user;
            }
            catch (System.Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("White on blue.");
                // return NotFound(ex.Message);
            }


            // var c = _context.Commentaires.Where(o => o.Id == commentaire.Id).Include(o => o.user).FirstOrDefault();

            // c.user.ImageUrl = ImageService.Get(c.user.ImageUrl, _hostingEnvironment.WebRootPath);
            await _hubContext.Clients.All.BroadcastComment(commentaire.Id, commentaire, user);
            await _hubContext2.Clients.All.BroadcastOne(1);
            //return CreatedAtAction("GetCommentaire", new { id = commentaire.Id }, commentaire);
            return NoContent();
        }

        // get: api/Commentaires
        [HttpGet("GetCountComment/{idOuvrier}")]
        public async Task<IActionResult> GetCountComment([FromRoute]int idOuvrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var t = await _context.Commentaires.Where(n => n.IdOuvrier == idOuvrier).CountAsync();


            //int t = await cm.SumAsync(p => p.SousCommentaires.Count()) + await cm.CountAsync();

            return Ok(t);
        }

        // DELETE: api/Commentaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            _context.Commentaires.Remove(commentaire);
            //await _context.SaveChangesAsync();
            int x = await _context.SaveChangesAsync();

            //vCommentaire vcommentaire = _mapper.Map<vCommentaire>(commentaire);
            //signalR
            await _hubContext.Clients.All.DeleteComment(id, commentaire);
            await _hubContext2.Clients.All.DeleteOne(-x);
            return Ok(commentaire);
        }

        private bool CommentaireExists(int id)
        {
            return _context.Commentaires.Any(e => e.Id == id);
        }
    }
}