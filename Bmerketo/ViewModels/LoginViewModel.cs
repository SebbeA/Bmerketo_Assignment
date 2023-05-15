using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Enter your email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Enter your Password")]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
