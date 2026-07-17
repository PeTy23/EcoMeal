using EcoMeal.Database.Entities;

namespace EcoMeal.Services.interfaces;

public interface IUserService
{
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
    Task<bool> RequestPartnerStatusAsync(string userId);

    Task<List<ApplicationUser>> GetPendingPartnerRequestsAsync();
    Task<bool> ApprovePartnerRequestAsync(string userId);
    Task<bool> DenyPartnerRequestAsync(string userId);
    Task<bool> IsUserBusinessManagerAsync(string userId);
    Task<List<ApplicationUser>> GetBusinessManagersAsync();
}