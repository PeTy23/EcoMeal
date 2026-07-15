using EcoMeal.Database.Entities;

namespace EcoMeal.Repositories.interfaces;

public interface IBusinessRepository
{
    public Task<List<Business>> GetAllAsync();

    public Task<Business?> GetById(Guid Id);

    public Task AddAsync(Business business);

    public Task DeleteAsync(Guid Id);

    public Task SaveChangesAsync();
}
