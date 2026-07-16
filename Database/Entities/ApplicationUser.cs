using Microsoft.AspNetCore.Identity;

namespace EcoMeal.Database.Entities;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }

    public bool HasPendingPartnerRequest { get; set; } = false;
    public ICollection<Order> Orders { get; set; }

    public ICollection<Business> Businesses { get; set; }
}
