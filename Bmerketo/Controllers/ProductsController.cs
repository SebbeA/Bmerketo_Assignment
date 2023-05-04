using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
