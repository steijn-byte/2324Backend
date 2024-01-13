using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BackendApp.Entities;
using BackendApp.Interfaces;

namespace BackendApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel login)
        {
            Console.WriteLine("Login request received for: " +login.Email.ToString(), login.Password.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user =  _userService.LoginUser(login.Email, login.Password);

            if (user == null)
            {
                return BadRequest("Invalid Request");
            }
            //jwt token generation
            Console.WriteLine("Generating token");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims: new List<Claim>
              {
                  new Claim(ClaimTypes.Role, "User"),
                  new Claim(ClaimTypes.Name, login.Email),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            Response.Headers.Add("Content-Type", "text/plain");
            return Ok(token);
        }
    }
}
