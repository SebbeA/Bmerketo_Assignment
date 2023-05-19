using Bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels;

public class AddProductFormViewModel
{
    [Required(ErrorMessage = "Articlenumber required")]
    [Display(Name = "Articlenumber * (exampel: 1234asf1241af)")]
    public string ArticleNumber { get; set; } = null!;

    [Required(ErrorMessage = "Title on the product is required")]
    [Display(Name = "Title on product *")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Price of the product is required")]
    [Display(Name = "Price *")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Product image is required")]
    [Display(Name = "Product image *")]
    public string ImageUrl { get; set; } = null!;

    [Display(Name = "Description of the product (optional)")]
    public string? Description { get; set; }



    public static implicit operator ProductEntity(AddProductFormViewModel addProductFormViewModel)
    {
        return new ProductEntity
        {
            ArticleNumber = addProductFormViewModel.ArticleNumber,
            ProductName = addProductFormViewModel.ProductName,
            Price = addProductFormViewModel.Price,
            ImageUrl = addProductFormViewModel.ImageUrl,
            Description = addProductFormViewModel.Description
        };
    }
}
