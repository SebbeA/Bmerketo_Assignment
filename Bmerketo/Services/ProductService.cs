using Bmerketo.Models.Entities;
using Bmerketo.Repositories;

namespace Bmerketo.Services;

public class ProductService
{
    #region constructors & private fields

    private readonly ProductRepository _productRepo;
    private readonly ProductTagRepository _productTagRepo;

    public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
    }

    #endregion

    public async Task<bool> CreateAsync(ProductEntity productEntity)
    {
        var _productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == productEntity.ArticleNumber);
        if (_productEntity == null)
        {
            _productEntity = await _productRepo.AddAsync(productEntity);
            if (_productEntity != null)
                return true;
        }

        return false;
    }

    public async Task AddProductTagsAsync(ProductEntity productEntity, string[] tags)
    {
        foreach(var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = productEntity.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }
}
