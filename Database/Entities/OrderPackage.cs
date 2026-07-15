using EcoMeal.Database.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMeal.Database.Entities;

public class OrderPackage
{
    public required Guid Id { get; set; }
    public required Guid OrderId { get; set; }
    public required Guid PackageId { get; set; }
    public int Quantity { get; set; }
    //public ICollection <Order> Orders { get; set; } 

    //public ICollection<Package> Packages { get; set; }

    [ForeignKey("OrderId")]

    public required Order Order { get; set; }

    [ForeignKey("PackageId")]
    public required Package Package { get; set; }
}
