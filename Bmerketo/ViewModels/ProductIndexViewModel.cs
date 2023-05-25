using Bmerketo.Models.Dtos;

namespace Bmerketo.ViewModels;

public class ProductIndexViewModel
{
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}
