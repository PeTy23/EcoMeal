using EcoMeal.Database.Entities;
using EcoMeal.Repositories.interfaces;
using EcoMeal.Services.interfaces;

namespace EcoMeal.Services;

public class PackageServices(IPackageRepository packageRepository) : IPackageService
{
    public async Task<List<Package>> GetAllAsync()
    {
        return await packageRepository.GetAllAsync();
    }

    public async Task<Package?> GetByIdAsync(Guid id)
    {
        return await packageRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Package package)
    {
        if (package.Id == Guid.Empty)
        {
            package.Id = Guid.NewGuid();
        }

        await packageRepository.AddAsync(package);
        await packageRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Package package)
    {
        var existingPackage = await packageRepository.GetByIdAsync(package.Id);

        if (existingPackage != null)
        {
            existingPackage.Name = package.Name;
            existingPackage.Description = package.Description;
            existingPackage.Price = package.Price;
            existingPackage.Quantity = package.Quantity;
            existingPackage.PickupStart = package.PickupStart;
            existingPackage.PickupEnd = package.PickupEnd;
            existingPackage.ImageUrl = package.ImageUrl;

            // Actualizăm cheile externe (asigură-te că aceste denumiri sunt corecte în Package.cs)
            existingPackage.BusinessId = package.BusinessId;
            existingPackage.PackageTypeId = package.PackageTypeId;

            await packageRepository.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        await packageRepository.DeleteAsync(id);
        await packageRepository.SaveChangesAsync();
    }
}
