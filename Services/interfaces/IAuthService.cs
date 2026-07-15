using EcoMeal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace EcoMeal.Services.interfaces
{
    public interface IAuthService
    {
        public Task<SignInResult> LoginAsync(LoginRequest request);
        public Task<SignInResult> RegisterAsync(CustomRegisterRequest request);

        public Task LogoutAsync();
    }
}