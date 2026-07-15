using EcoMeal.Services.interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest request, [FromQuery] string? returnUrl)
        {
            var result = await authService.LoginAsync(request);
            if (result.Succeeded)
                return LocalRedirect(returnUrl ?? "/");

            return LocalRedirect($"/account/login?error=Invalid login&returnUrl={returnUrl}");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request, [FromQuery] string? returnUrl, [FromForm] string? name)
        {
            var result = await authService.RegisterAsync(request, name);
            if (result.Succeeded)
                return LocalRedirect(returnUrl ?? "/");

            return LocalRedirect($"/account/register?error=Registration failed&returnUrl={returnUrl}");
        }

        [HttpPost("logout")]

        public async Task<IActionResult> Logout([FromQuery] string? returnUrl)
        {
            await authService.LogoutAsync();
            return LocalRedirect(returnUrl ?? "/");
        }

    }


}