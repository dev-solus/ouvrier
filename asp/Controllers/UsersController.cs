using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using asp.Models;
using asp.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;
using asp3.Models.Repository;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace asp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IDataRepository<User> _dataRepository;
        public UsersController(IOptions<AppSettings> appSettings, IDataRepository<User> dataRepository)
        {
            _appSettings = appSettings.Value;
            _dataRepository = dataRepository;
        }

        // IActionResult TokenHandler(User user)
        // {
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(new Claim[]
        //         {
        //             new Claim(ClaimTypes.Name, user.Id.ToString())
        //         }),
        //         Expires = DateTime.UtcNow.AddDays(7),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //     };
        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     var tokenString = tokenHandler.WriteToken(token);

        //     // return basic user info (without password) and token to store client side
        //     user.ImageUrl = ImageService.Get(user.ImageUrl, _hostingEnvironment.WebRootPath);
        //     return Ok(new
        //     {
        //         user = _mapper.Map<UserDto>(user),
        //         Token = tokenString
        //     });
        // }

        [AllowAnonymous]
        [HttpPost("postFile")]
        public IActionResult PostImage(IFormFile file)
        {
            String msg = _dataRepository.PostImage(file);

            return Ok(new {msg = msg});
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginDto userDto)
        {
            User user = _dataRepository.LogIn(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new { user = user, Token = "tokenString" });
        }
        public class LoginDto
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                _dataRepository.Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dataRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_dataRepository.Get(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User user)
        {
            try
            {
                _dataRepository.Update(user);
                user.location = null;
                // user.location.users = null;
                return Ok(new { user = user, Token = "tokenString" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dataRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
