using EcoMeal.Database.Entities.Enums;

namespace EcoMeal.Database.Entities;

public class PackageType
{
    public required PackageTypeEnum Id { get; set; }
    public string Name { get; set; }
}
