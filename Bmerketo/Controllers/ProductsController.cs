using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            return View();
        }

        public IActionResult Details()
        {
            ViewData["Title"] = "Products";

            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create product";

            return View();
        }
    }
}
