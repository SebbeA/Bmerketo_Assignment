using Bmerketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class LogoutController : Controller
{
    public readonly AuthService _authService;

    public LogoutController(AuthService authService)
    {
        _authService = authService;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        if (await _authService.LogOutAsync(User))
            return LocalRedirect("/");

        return RedirectToAction("Index", "Profile");

    }
}
