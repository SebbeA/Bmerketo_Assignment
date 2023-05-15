using Bmerketo.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "You need to enter your first name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a correct first name")]
    [Display(Name = "First Name *")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You need to enter your last name")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a correct last name")]
    [Display(Name = "Last Name *")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You need to enter your E-mail")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a correct E-mail")]
    [Display(Name = "E-mail *")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You need to enter a password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You need to enter a correct password")]
    [Display(Name = "Password *")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "You need to confirm your password")]
    [Compare(nameof(Password), ErrorMessage = "Your password doesn't match")]
    [Display(Name = "Confirm Password *")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Street Name (optional)")]
    public string? StreetName { get; set; }

    [Display(Name = "Postal Code (optional)")]
    public string? PostalCode { get; set; }

    [Display(Name = "City (optional)")]
    public string? City { get; set; }

    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Upload Profile Image (optional)")]
    public string? ProfileImage { get; set; }

    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }

    public static implicit operator CustomIdentityUser(RegisterViewModel registerViewModel)
    {
        return new CustomIdentityUser
        {
            UserName = registerViewModel.Email,
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            Email = registerViewModel.Email,
            PhoneNumber = registerViewModel.PhoneNumber,
        };
    }
}
