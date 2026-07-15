using EcoMeal.Database.Entities.Enums;

namespace EcoMeal.Database.Entities;

public class OrderStatus
{
    public required OrderStatusEnum Id { get; set; }
    public required string Name { get; set; }
}
