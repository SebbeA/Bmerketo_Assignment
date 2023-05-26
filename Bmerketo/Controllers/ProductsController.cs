using Bmerketo.Contexts;
using Bmerketo.Models.Dtos;
using Bmerketo.Models.Entities;
using Bmerketo.Services;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<IActionResult> Index(string tag)
    {
        IEnumerable<Product> products;

        if (string.IsNullOrEmpty(tag) || tag == "untagged")
        {
            products = await _productService.GetProductsIncludingUntaggedAsync();
        }
        else
        {
            products = await _productService.GetProductsByTagAsync(tag);
        }

        var tags = await _tagService.GetTagsAsync();
        var tagEntities = tags.Select(t => new TagEntity { TagName = t.Text, Id = int.Parse(t.Value) }).ToList();

        var viewModel = new ProductIndexViewModel
        {
            Products = products,
            Tags = tagEntities
        };

        return View(viewModel);

        //var viewModel = new ProductIndexViewModel
        //{
        //    Products = await _productService.GetAllAsync()
        //};

        //return View(viewModel);
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
        var tags = await _tagService.GetTagsAsync();
        var selectListItems = tags.Select(t => new SelectListItem
        {
            Value = t.Value.ToString(),
            Text = t.Text
        });

        var viewModel = new AddProductFormViewModel
        {
            Tags = selectListItems.ToList()
        };

        return View(viewModel);
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

        var allTags = await _tagService.GetTagsAsync();
        var selectListItems = allTags.Select(t => new SelectListItem
        {
            Value = t.Value.ToString(),
            Text = t.Text,
            Selected = tags != null && tags.Contains(t.Value)
        });

        addProductFormViewModel.Tags = selectListItems.ToList();

        return View(addProductFormViewModel);
    }


    //[Authorize(Roles = "admin")]
    //public async Task<IActionResult> Create()
    //{
    //    var tags = await _tagService.GetTagsAsync();

    //    ViewBag.Tags = tags.Select(t => new TagEntity { TagName = t.Text, Id = int.Parse(t.Value) }).ToList();

    //    return View();

    //    //ViewBag.Tags = await _tagService.GetTagsAsync();

    //    //return View();
    //}

    //[Authorize(Roles = "admin")]
    //[HttpPost]
    //public async Task<IActionResult> Create(AddProductFormViewModel addProductFormViewModel, string[] tags)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var product = await _productService.CreateAsync(addProductFormViewModel);
    //        if (product != null) 
    //        {
    //            await _productService.AddProductTagsAsync(addProductFormViewModel, tags);

    //            if (addProductFormViewModel.ImageUrl != null)
    //            {
    //                await _productService.UploadImageAsync(product, addProductFormViewModel.ImageUrl);
    //            }

    //            return RedirectToAction("Index", "Products");
    //        }

    //        ModelState.AddModelError("", "Something went wrong, please try again.");
    //    }

    //    ViewBag.Tags = await _tagService.GetTagsAsync(tags);

    //    return View(addProductFormViewModel);
    //}
}
