using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class ContactController : Controller
{
    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _contactService.CreateMessageAsync(viewModel))
            {
                TempData["AlertMessage"] = "Thank you! We got your message and we will contact you within 5 days.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Sorry!, Something went wrong. Please try again.");
        }

        return View(viewModel);
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";

        return View();
    }
}
