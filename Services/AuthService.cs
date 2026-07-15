using EcoMeal.Constants;
using EcoMeal.Database.Entities;
using EcoMeal.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace EcoMeal.Services;

public class AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : IAuthService
{
    public async Task<SignInResult> LoginAsync(LoginRequest request)
    {
        return await signInManager.PasswordSignInAsync(
            request.Email, request.Password, true, false);
    }

    public async Task<SignInResult> RegisterAsync(RegisterRequest request, string name)
    {
        if (await userManager.FindByEmailAsync(request.Email) is not null)
        {
            return SignInResult.Failed;
        }

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FullName = name,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return SignInResult.Failed;
        }

        await userManager.AddToRoleAsync(user, AppRoles.Customer);

        return await signInManager.PasswordSignInAsync(
            request.Email, request.Password, true, false);
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}