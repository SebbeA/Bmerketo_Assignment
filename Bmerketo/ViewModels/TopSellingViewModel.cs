namespace Bmerketo.ViewModels;

public class TopSellingViewModel
{
    public string? Title { get; set; }
    public bool Arrows { get; set; } = false;
    public IEnumerable<ProductCardItemViewModel> TopSelling { get; set; } = null!;
}
