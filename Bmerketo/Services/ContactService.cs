using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.ViewModels;

namespace Bmerketo.Services;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateMessageAsync(ContactFormViewModel contactFormViewModel)
    {
        try
        {
            ContactFormEntity contactFormEntity = contactFormViewModel;

            _context.ContactMessage.Add(contactFormEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }
}
