using Bmerketo.Models.Dtos;
using Bmerketo.Models.Entities;

namespace Bmerketo.ViewModels;

public class ProductIndexViewModel
{
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
    public ICollection<TagEntity>? Tags { get; set; }
}
