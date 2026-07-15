using EcoMeal.Database.Entities.Enums;

namespace EcoMeal.Database.Entities;
public class BusinessType
{
    public required BusinessTypeEnum Id { get; set; }
    public string Name { get; set; }
}
