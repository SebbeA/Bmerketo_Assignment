﻿using Bmerketo.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmerketo.Models.Entities;

public class ProductEntity
{
    [Key]
    [Required]
    public string ArticleNumber { get; set; } = null!;

    [Required]
    public string ProductName { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Required]
    public string ImageUrl { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<ProductTagEntity> ProductTag { get; set; } = new HashSet<ProductTagEntity>();

    public static implicit operator Product(ProductEntity productEntity)
    {
        return new Product
        {
            ArticleNumber = productEntity.ArticleNumber,
            ProductName = productEntity.ProductName,
            Price = productEntity.Price,
            ImageUrl = productEntity.ImageUrl,
            Description = productEntity.Description,
            Tags = productEntity.ProductTag
        };
    }
}
