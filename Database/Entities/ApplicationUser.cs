using Microsoft.AspNetCore.Identity;

namespace EcoMeal.Database.Entities;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; }

    public ICollection<Order> Orders { get; set; }
}
