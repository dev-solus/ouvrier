using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly MyContext _context;
        private IWebHostEnvironment _hostingEnvironment;
        public SearchController(IWebHostEnvironment hostingEnvironment, MyContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        // GET: api/Villes
        [HttpGet("Get/{idVille}/{idQuartier}/{idMetier}")]
        public async Task<IEnumerable<User>> Get(int idVille, int idQuartier, int idMetier/*, int startIndex, int pageSize*/)
        {

            var usersFiltred = _context.Users
                .Include(o => o.metier)
                .Include(o => o.location)
                    .ThenInclude(o => o.quartier)
                        .ThenInclude(o => o.ville)
                .Where(o => o.location.quartier.IdVille == idVille);

            if (idQuartier != 0)
            {
                usersFiltred = _context.Users
                .Include(o => o.metier)
                .Include(o => o.location)
                    .ThenInclude(o => o.quartier)
                        .ThenInclude(o => o.ville)
                .Where(o => o.location.quartier.IdVille == idVille)
                .Where(o => o.location.IdQuartier == idQuartier);
            }

            if (idMetier != 0)
            {
                usersFiltred = _context.Users
                .Include(o => o.metier)
                .Include(o => o.location)
                    .ThenInclude(o => o.quartier)
                        .ThenInclude(o => o.ville)
                .Where(o => o.location.quartier.IdVille == idVille)
                .Where(o => o.IdMetier == idMetier)
                .Where(o => o.location.IdQuartier == idQuartier);
            }


            //if(idQuartier != 0)
            //    l.Where(o => o.IdLocationNavigation.IdQuartier == idQuartier);

            // set the correct form of image user
            // and get all locations for map google
            List<Location> locations = new List<Location>();
            // foreach (var u in usersFiltred)
            // {
            //     // u.ImageUrl = ImageService.Get(u.ImageUrl, _hostingEnvironment.WebRootPath);
            //     locations.Add(u.location);
            // }

            await usersFiltred.ForEachAsync(user => locations.Add(user.location));
            await usersFiltred.ForEachAsync(user => user.location.users = null);
            // var ll = _mapper.Map<IEnumerable<vLocation>>(locations);
            return usersFiltred;
        }
    }
}
