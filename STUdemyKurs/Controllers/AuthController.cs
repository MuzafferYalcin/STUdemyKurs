using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using STUdemyKurs.DTOs;
using STUdemyKurs.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace STUdemyKurs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public readonly IConfiguration _config;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> Register(User user)
        {
            /*var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Name = userDto.Name,

            };*/
            var result = await _userManager.CreateAsync(user, "Senben_1");
            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserForLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return BadRequest(new { message = "username bulunamadı" });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = GenerateJwtToken(user)
                });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
