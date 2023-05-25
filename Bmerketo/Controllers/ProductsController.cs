using Bmerketo.Contexts;
using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Controllers;

public class ProductsController : Controller
{
    #region constructors & private fields

    private readonly TagService _tagService;
    private readonly ProductService _productService;
    private readonly DataContext _context;

    public ProductsController(TagService tagService, ProductService productService, DataContext context)
    {
        _tagService = tagService;
        _productService = productService;
        _context = context;
    }

    #endregion

    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductIndexViewModel
        {
            Products = await _productService.GetAllAsync()
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Details(string Id)
    {
        var product = await _context.Product.FirstOrDefaultAsync(x => x.ArticleNumber == Id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
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
            var product = await _productService.CreateAsync(addProductFormViewModel);
            if (product != null) 
            {
                await _productService.AddProductTagsAsync(addProductFormViewModel, tags);

                if (addProductFormViewModel.ImageUrl != null)
                {
                    await _productService.UploadImageAsync(product, addProductFormViewModel.ImageUrl);
                }
                
                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Something went wrong, please try again.");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);

        return View(addProductFormViewModel);
    }
}
