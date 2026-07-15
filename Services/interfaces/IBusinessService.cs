using EcoMeal.Database.Entities;

namespace EcoMeal.Services.interfaces;

public interface IBusinessService
{
    public Task<List<Business>> GetAll();
    public Task AddAsync(Business business);

    Task<Business?> GetByIdAsync(Guid id);
    Task UpdateAsync(Business business);
    Task DeleteAsync(Guid id);

}
