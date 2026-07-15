using EcoMeal.Database.Entities;

namespace EcoMeal.Services.interfaces
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(Guid id);
        Task AddAsync(Package package);
        Task UpdateAsync(Package package);
        Task DeleteAsync(Guid id);
    }
}
