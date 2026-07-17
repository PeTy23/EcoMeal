using EcoMeal.Database.Entities;
using EcoMeal.Repositories;
using EcoMeal.Repositories.interfaces;
using EcoMeal.Services.interfaces;

namespace EcoMeal.Services;

public class BusinessServices(IBusinessRepository businessRepository) : IBusinessService
{
    public async Task<List<Business>> GetAll()
    {
        return await businessRepository.GetAllAsync();
    }

    public async Task AddAsync(Business business)
    {
        await businessRepository.AddAsync(business);
        await businessRepository.SaveChangesAsync();
    }

    public async Task<Business?> GetByIdAsync(Guid id)
    {
        return await businessRepository.GetById(id);
    }

    public async Task UpdateAsync(Business business)
    {
        var businessEntity = await businessRepository.GetById(business.Id);
        if (businessEntity == null)
        {
            return;
        }

        businessEntity.Name = business.Name;
        //mapper
        await businessRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await businessRepository.DeleteAsync(id);
        await businessRepository.SaveChangesAsync();
    }

    public async Task ToggleApprovalAsync(Guid id)
    {
        var businessEntity = await businessRepository.GetById(id);
        if (businessEntity != null)
        {
            // Inversăm statusul curent (din true în false, sau din false în true)
            businessEntity.isApproved = !businessEntity.isApproved;
            await businessRepository.SaveChangesAsync();
        }
    }
}
