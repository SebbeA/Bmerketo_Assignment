namespace Bmerketo.ViewModels;

public class DetailedProductCardViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
}
