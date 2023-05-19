using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Models.Entities;

[PrimaryKey(nameof(ArticleNumber), nameof(TagId))]
public class ProductTagEntity
{
    public string ArticleNumber { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;

    public int TagId { get; set; }
    public TagEntity Tags { get; set; } = null!;
}
