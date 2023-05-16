using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthService _authService;

        public RegisterController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.RegisterAsync(registerViewModel))
                    return RedirectToAction("Index", "Login");

                ModelState.AddModelError("", "A user with the same email already exists");
            }

            return View(registerViewModel);
        }
    }
}
