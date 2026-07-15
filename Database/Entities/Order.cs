using EcoMeal.Database.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoMeal.Database.Entities;

public class Order
{
    public Guid Id { get; set; }
    public required string UserId { get; set; }

    public required Guid BussinesId { get; set; }

    public string OrderNumber { get; set; }

    public required OrderStatusEnum Status { get; set; }

    public ICollection<OrderPackage> OrderPackages { get; set; }

    [ForeignKey("UserId")]
    public required ApplicationUser User { get; set; }

    [ForeignKey("BussinesId")]
    public required Business Business { get; set; }
    



}
