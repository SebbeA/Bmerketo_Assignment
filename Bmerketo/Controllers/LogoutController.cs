using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class LogoutController : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    public LogoutController(SignInManager<CustomIdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Index", "Login");

    }
}
