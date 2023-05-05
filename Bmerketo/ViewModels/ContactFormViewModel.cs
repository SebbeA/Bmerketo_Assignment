using Bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "You must enter your name")]
    [Display(Name = "Your Name*")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "You must enter an Email")]
    [Display(Name = "Your Email*")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phonenumber (Optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company (Optional)")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "You must enter a message to us")]
    [Display(Name = "Message*")]
    public string Message { get; set; } = null!;

    public bool RememberMe { get; set; }

    public static implicit operator ContactFormEntity(ContactFormViewModel contactFormViewModel)
    {
        return new ContactFormEntity
        {
            Name = contactFormViewModel.Name,
            Email = contactFormViewModel.Email,
            PhoneNumber = contactFormViewModel.PhoneNumber,
            CompanyName = contactFormViewModel.CompanyName,
            Message = contactFormViewModel.Message
        };
    }
}
