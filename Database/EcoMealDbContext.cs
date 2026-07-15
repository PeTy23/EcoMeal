using EcoMeal.Database.Entities;
using EcoMeal.Database.Entities.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace EcoMeal.Database;

public class EcoMealDbContext : IdentityDbContext<ApplicationUser>
{
    public EcoMealDbContext(DbContextOptions<EcoMealDbContext> options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<PackageType> PackageTypes { get; set; }

    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessType> BusinessTypes { get; set; }

    public DbSet<OrderPackage> OrderPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<int>();



        builder.Entity<OrderStatus>().HasData(
            new OrderStatus { Id = (Entities.Enums.OrderStatusEnum)1, Name = "Pending" },
            new OrderStatus { Id = (Entities.Enums.OrderStatusEnum)2, Name = "Shipped" },
            new OrderStatus { Id = (Entities.Enums.OrderStatusEnum)3, Name = "Delivered" }
        );

        builder.Entity<BusinessType>().HasData(
          new BusinessType { Id = (Entities.Enums.BusinessTypeEnum)1, Name = "Restaurant" },
          new BusinessType { Id = (Entities.Enums.BusinessTypeEnum)2, Name = "Patiserie" },
          new BusinessType { Id = (Entities.Enums.BusinessTypeEnum)3, Name = "Cafe" },
          new BusinessType { Id = (Entities.Enums.BusinessTypeEnum)4, Name = "Supermarket" }
        );

        builder.Entity<PackageType>().HasData(
            new PackageType { Id = PackageTypeEnum.Bakery, Name = "Bakery" },
            new PackageType { Id = PackageTypeEnum.Beverage, Name = "Beverage" },
            new PackageType { Id = PackageTypeEnum.Dairy, Name = "Dairy" },
            new PackageType { Id = PackageTypeEnum.FrozenFood, Name = "Frozen Food" },
            new PackageType { Id = PackageTypeEnum.Meat, Name = "Meat" },
            new PackageType { Id = PackageTypeEnum.Produce, Name = "Produce" }
        );

        builder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<OrderPackage>().HasOne(o => o.Order).WithMany(u => u.OrderPackages).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<OrderPackage>().HasOne(o => o.Package).WithMany(u => u.OrderPackages).OnDelete(DeleteBehavior.Restrict);

    }
}
