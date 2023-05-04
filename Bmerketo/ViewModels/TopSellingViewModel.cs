namespace Bmerketo.ViewModels;

public class TopSellingViewModel
{
    public string? Title { get; set; }
    public bool Arrows { get; set; } = false;
    public IEnumerable<ProductCardItemSmallViewModel> TopSelling { get; set; } = null!;
}
