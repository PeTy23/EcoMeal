using EcoMeal.Database.Entities;

namespace EcoMeal.Repositories.interfaces
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(Guid id);
        Task AddAsync(Package package);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
