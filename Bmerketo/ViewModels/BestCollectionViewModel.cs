namespace Bmerketo.ViewModels;

public class BestCollectionViewModel
{
    public string? Title { get; set; }
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<ProductCardItemSmallViewModel> GridItems { get; set; } = null!;

    public bool LoadMore { get; set; } = false;
}
