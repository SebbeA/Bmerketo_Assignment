using Bmerketo.Contexts;
using Bmerketo.Models.Dtos;
using Bmerketo.Models.Entities;
using Bmerketo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services;

public class ProductService
{
    #region constructors & private fields

    private readonly ProductRepository _productRepo;
    private readonly DataContext _context;
    private readonly ProductTagRepository _productTagRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, IWebHostEnvironment webHostEnvironment, DataContext context)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

    #endregion

    public async Task<Product> CreateAsync(ProductEntity productEntity)
    {
        var _productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == productEntity.ArticleNumber);
        if (_productEntity == null)
        {
            _productEntity = await _productRepo.AddAsync(productEntity);
            if (_productEntity != null)
                return _productEntity;
        }

        return null!;
    }
    public async Task AddProductTagsAsync(ProductEntity productEntity, string[] tags)
    {
        foreach (var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = productEntity.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }
    public async Task<bool> UploadImageAsync(Product product, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/Images/products/{product.ImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch { return false; }
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var items = await _productRepo.GetAllAsync();
        var list = new List<Product>();
        foreach (var item in items)
            list.Add(item);

        return list;
    }
}