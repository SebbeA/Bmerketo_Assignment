using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Bmerketo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IdentityContext _identityContext;
    private readonly UserService _userService;

    public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IdentityContext identityContext, UserService userService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _identityContext = identityContext;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetUsersAsync();

        return View(users);
    }
}
