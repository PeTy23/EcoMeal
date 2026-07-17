using EcoMeal.Database.Entities;
using EcoMeal.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Services;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }

    public async Task<bool> RequestPartnerStatusAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return false;

        // Setăm flag-ul pe true
        user.HasPendingPartnerRequest = true;

        // UserManager se ocupă automat de salvarea în baza de date
        var result = await userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> ApprovePartnerRequestAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return false;

        // Scoatem statusul de "în așteptare"
        user.HasPendingPartnerRequest = false;
        await userManager.UpdateAsync(user);

        // Îi adăugăm rolul dacă nu îl are deja
        if (!await userManager.IsInRoleAsync(user, "BusinessManager"))
        {
            await userManager.AddToRoleAsync(user, "BusinessManager");
        }

        return true;
    }

    public async Task<bool> DenyPartnerRequestAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return false;

        // Pur și simplu setăm cererea pe false. Utilizatorul va putea aplica din nou.
        user.HasPendingPartnerRequest = false;
        var result = await userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> IsUserBusinessManagerAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return false;

        return await userManager.IsInRoleAsync(user, "BusinessManager");
    }

    public async Task<List<ApplicationUser>> GetPendingPartnerRequestsAsync()
    {
        // Preluăm toți utilizatorii care au bifată cererea de parteneriat
        return await userManager.Users
            .Where(u => u.HasPendingPartnerRequest)
            .ToListAsync();
    }
}