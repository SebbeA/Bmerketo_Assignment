using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bmerketo.Services;

public class AuthService
{
    private readonly UserManager<CustomIdentityUser> _userManager;

    public AuthService(UserManager<CustomIdentityUser> userManager)
    {
        _userManager = userManager;
    }

    //public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    //{
    //    var result = await _userManager.CreateAsync(, registerViewModel.Password);
    //    return result.Succeeded;
    //}
}
