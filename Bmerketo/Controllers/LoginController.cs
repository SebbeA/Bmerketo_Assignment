using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class LoginController : Controller
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
           if (await _authService.LogInAsync(loginViewModel))
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Incorrect email or password");
        }

        return View(loginViewModel);
    }
}
