using Bmerketo.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Bmerketo.Models.Entities;

public class ContactFormEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }

    [Required]
    public string Message { get; set; } = null!;

    public static implicit operator ContactFormViewModel(ContactFormEntity contactFormEntity)
    {
        return new ContactFormViewModel
        {
            Name = contactFormEntity.Name,
            Email = contactFormEntity.Email,
            PhoneNumber = contactFormEntity.PhoneNumber,
            CompanyName = contactFormEntity.CompanyName,
            Message = contactFormEntity.Message
        };
    }
}
