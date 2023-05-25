using Bmerketo.Models.Entities;
using Bmerketo.Repositories;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bmerketo.Services;

public class TagService
{
    #region constructors & private fields

    private readonly TagRepository _tagRepo;
    private readonly ProductTagRepository _productTagRepo;

    public TagService(TagRepository tagRepo, ProductTagRepository productTagRepo)
    {
        _tagRepo = tagRepo;
        _productTagRepo = productTagRepo;
    }

    #endregion
    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName
            });
        }

        return tags;
    }

    public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName,
                Selected = selectedTags!.Contains(tag.Id.ToString())
            });
        }

        return tags;
    }

    public async Task AddTagAsync(AddProductFormViewModel addProductFormViewModel, string[] tags)
    {
        foreach (var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = addProductFormViewModel.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }
}
