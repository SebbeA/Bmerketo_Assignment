namespace Bmerketo.ViewModels;

public class UpToSellViewModel
{
    public string? Title { get; set; }
    public string? TitleRed { get; set; }
    public string? Ingress { get; set; }
    public string? Text { get; set; }
    public string? LinkContent { get; set; }

    public IEnumerable<ProductCardItemSmallViewModel> Item1 { get; set; } = null!;
    public IEnumerable<ProductCardItemSmallViewModel> Item2 { get; set; } = null!;

}
