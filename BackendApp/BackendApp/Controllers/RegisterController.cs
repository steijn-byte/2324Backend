using BackendApp.Entities;
using BackendApp.Interfaces;
using BackendApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        
        public RegisterController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        // GET: RegisterController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
            try
            {
                User userToRegister = new User()
                {
                    Username = user.Username,
                    Id = Guid.NewGuid(),
                    Email = user.Email,
                    Password = user.Password
                };
                var result = await userService.RegisterUser(userToRegister);
                return Ok(result);
            }
            catch
            {
                return View();
            }
        } 
    }
}
