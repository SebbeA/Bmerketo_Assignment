using Bmerketo.Contexts;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bmerketo.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly SeedService _seedService;
    private readonly AddressService _addressService;

    public AuthService(UserManager<AppUser> userManager, IdentityContext identityContext, SignInManager<AppUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager, AddressService addressService)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _seedService = seedService;
        _roleManager = roleManager;
        _addressService = addressService;
    }

    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            AppUser appUser = registerViewModel;

            var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);

            await _userManager.AddToRoleAsync(appUser, roleName);
            if (result.Succeeded)
            {
                var addressEntity = await _addressService.GetOrCreateAsync(registerViewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }

            return false;
        } 
        catch 
        { 
            return false; 
        }
    }

    public async Task<bool> LogInAsync(LoginViewModel loginViewModel)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);
        if (appUser != null)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.RememberMe, false);
            return result.Succeeded;
        }

        return false;
    }

    public async Task<bool> LogOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }
}
