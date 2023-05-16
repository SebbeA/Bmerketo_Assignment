using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class ProfileController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}
