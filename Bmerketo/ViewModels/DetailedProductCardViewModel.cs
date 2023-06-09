﻿namespace Bmerketo.ViewModels;

public class DetailedProductCardViewModel
{
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
}
