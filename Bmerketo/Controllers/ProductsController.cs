using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers;

public class ProductsController : Controller
{
    #region constructors & private fields

    private readonly TagService _tagService;
    private readonly ProductService _productService;

    public ProductsController(TagService tagService, ProductService productService)
    {
        _tagService = tagService;
        _productService = productService;
    }

    #endregion

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
    public async Task<IActionResult> Create()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();

        return View();
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Create(AddProductFormViewModel addProductFormViewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(addProductFormViewModel)) 
            {
                await _productService.AddProductTagsAsync(addProductFormViewModel, tags);
                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Something went wrong, please try again.");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);

        return View(addProductFormViewModel);
    }
}
