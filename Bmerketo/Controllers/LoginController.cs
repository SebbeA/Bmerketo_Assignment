using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    public LoginController(SignInManager<CustomIdentityUser> signInManager)
    {
        _signInManager = signInManager;
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
           var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Incorrect email or password");
        }

        return View(loginViewModel);
    }
}
