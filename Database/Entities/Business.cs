using EcoMeal.Database.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMeal.Database.Entities;

public class Business
{
    public Guid Id { get; set; }
    public BusinessTypeEnum BusinessTypeId { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
    public bool isApproved { get; set; } = false;

    [ForeignKey("BusinessTypeId")]
    public required BusinessType type { get; set; }

    public ICollection<Package> Packages { get; set; }

    public ICollection<Order> Orders { get; set; }

    public string? ManagerId { get; set; } //sau required string o sa  vedem

    [ForeignKey("ManagerId")]
    public ApplicationUser Manager { get; set; }
}
