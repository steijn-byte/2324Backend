using BackendApp.Entities;
using BackendApp.Interfaces;
using BackendApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
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
        public ActionResult Index()
        {
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            try
            {
                var result = await userService.RegisterUser(user);
                return Ok(result);
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
