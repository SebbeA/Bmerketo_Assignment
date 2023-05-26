using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<AppUser> _userManager;

    public UserService(IdentityContext identityContext, UserManager<AppUser> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
    {
        var users = await _identityContext.Users
            .Include(u => u.Addresses)
            .ThenInclude(a => a.Address)
            .ToListAsync();

        var userViewModels = new List<UserViewModel>();
        foreach (var user in users)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                Company = user.Company,
                PhoneNumber = user.PhoneNumber,
                StreetName = user.Addresses.FirstOrDefault()?.Address.StreetName!,
                City = user.Addresses.FirstOrDefault()?.Address.City!,
                PostalCode = user.Addresses.FirstOrDefault()?.Address.PostalCode!
            };

            var roles = await _userManager.GetRolesAsync(user);
            userViewModel.Roles = roles.ToList();

            userViewModels.Add(userViewModel);
        }

        return userViewModels;
    }
}
