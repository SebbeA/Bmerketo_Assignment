using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
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


    [Required(ErrorMessage = "You need to enter your Street name")]
    [Display(Name = "Street Name *")]
    public string StreetName { get; set; } = null!;


    [Required(ErrorMessage = "You need to enter your Postal Code")]
    [Display(Name = "Postal Code *")]
    public string PostalCode { get; set; } = null!;


    [Required(ErrorMessage = "You need to enter your City")]
    [Display(Name = "City *")]
    public string City { get; set; } = null!;


    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Upload Profile Image (optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }


    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }

    [Required(ErrorMessage = "You must aggree the terms and conditions")]
    [Display(Name = "I have read and accepts the terms and conditions")]
    public bool TermsAndAgreement { get; set; } = false;



    public static implicit operator AppUser(RegisterViewModel registerViewModel)
    {
        return new AppUser
        {
            UserName = registerViewModel.Email,
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            Email = registerViewModel.Email,
            PhoneNumber = registerViewModel.PhoneNumber,
            Company = registerViewModel.Company,
        };
    }

    public static implicit operator AddressEntity(RegisterViewModel registerViewModel)
    {
        return new AddressEntity
        {
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City
        };
    }
}
