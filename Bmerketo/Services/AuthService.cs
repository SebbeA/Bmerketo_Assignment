using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bmerketo.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly SeedService _seedService;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _seedService = seedService;
        _roleManager = roleManager;
    }

    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = registerViewModel;
            await _userManager.CreateAsync(identityUser, registerViewModel.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfile = registerViewModel;
            userProfile.UserId = identityUser.Id;

            _identityContext.UserProfiles.Add(userProfile);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> LogInAsync(LoginViewModel loginViewModel)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);

            return result.Succeeded;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> LogOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }
}
