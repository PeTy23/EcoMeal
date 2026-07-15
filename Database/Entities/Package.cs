using EcoMeal.Database.Entities.Enums;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace EcoMeal.Database.Entities;

public class Package
{
    public Guid Id { get; set; }
    public required Guid BusinessId { get; set; }
    public required PackageTypeEnum PackageTypeId { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required float Price { get; set; }
    public int Quantity { get; set; }

    public required DateTime PickupStart { get; set; }
    public required DateTime PickupEnd { get; set; }

    public ICollection<OrderPackage> OrderPackages { get; set; }
    public string ImageUrl { get; set; }

    [ForeignKey("BusinessId")]
    public Business Business { get; set; }

    [ForeignKey("PackageTypeId")]
    public PackageType PackageType { get; set; }

}
