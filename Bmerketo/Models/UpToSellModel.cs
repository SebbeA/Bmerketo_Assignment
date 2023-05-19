using Bmerketo.ViewModels;

namespace Bmerketo.Models;

public class UpToSellModel
{
    public string? Title { get; set; }
    public string? TitleRed { get; set; }
    public string? Ingress { get; set; }
    public string? Text { get; set; }
    public string? LinkContent { get; set; }

    public IEnumerable<ProductCardItemViewModel> Item1 { get; set; } = null!;
    public IEnumerable<ProductCardItemViewModel> Item2 { get; set; } = null!;
}
