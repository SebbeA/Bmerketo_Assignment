﻿using Bmerketo.Models.Entities;

namespace Bmerketo.Models;

public class ProductModel
{
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<ProductTagEntity> Tags { get; set; } = null!;
}
