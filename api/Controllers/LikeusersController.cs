using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using asp.SignalR;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeusersController : ControllerBase
    {
        private readonly MyContext _context;
        private IHubContext<Like, ILikeHubClient> _hubContext;
        //
        public LikeusersController(MyContext context,IHubContext<Like, ILikeHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Likeusers
        [HttpGet("CheckUserLikes/{IdOuvrier}/{idUser}")]
        public async Task<IActionResult> CheckUserLikes(int IdOuvrier, int idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isLicked = await _context.Likeusers.FindAsync(IdOuvrier, idUser);

            if (isLicked == null)
            {
                return Ok(0);
            }

            return Ok(1);
        }

        [HttpGet("GetCountLikePerUser/{id}")]
        public async Task<IActionResult> GetCountLikePerUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int t = await _context.Likeusers.Where(m => m.IdOuvrier == id).CountAsync();

            return Ok(t);
        }

        // PUT: api/Likeusers/5
        [HttpPut("{id}")]
        // public async Task<IActionResult> PutLikeuser([FromRoute] int id, [FromBody] Likeuser likeuser)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (id != likeuser.IdUser)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(likeuser).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!LikeuserExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Likeusers
        [HttpPost]
        public async Task<IActionResult> PostLikeuser([FromBody] Likeuser likeuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Likeusers.Add(likeuser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LikeuserExists(likeuser.IdUser))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            await _hubContext.Clients.All.BroadcastLike(likeuser.IdOuvrier);
            return Ok();
        }

        // DELETE: api/Likeusers/5
        [HttpDelete("DeleteLikeuser/{IdOuvrier}/{idUser}")]
        public async Task<IActionResult> DeleteLikeuser([FromRoute] int IdOuvrier, int idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var likeuser = await _context.Likeusers.FindAsync(IdOuvrier, idUser);
            if (likeuser == null)
            {
                return NotFound();
            }

            _context.Likeusers.Remove(likeuser);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.DeleteLike(IdOuvrier);
            return Ok();
        }

        private bool LikeuserExists(int id)
        {
            return _context.Likeusers.Any(e => e.IdUser == id);
        }
    }
}