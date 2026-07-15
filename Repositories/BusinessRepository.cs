using EcoMeal.Database;
using EcoMeal.Database.Entities;
using EcoMeal.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Repositories;

public class BusinessRepository(EcoMealDbContext context) : IBusinessRepository
{

    public async Task<List<Business>> GetAllAsync()
    {
        return await context.Businesses.Include(b => b.type).ToListAsync();
    }

    public async Task<Business?> GetById(Guid Id)
    {
        return await context.Businesses.FirstOrDefaultAsync(b => b.Id == Id);
    }

    public async Task AddAsync(Business business)
    {
        await context.Businesses.AddAsync(business);
        //await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid Id)
    {
        var business = await context.Businesses.FirstOrDefaultAsync(b => b.Id == Id);

        if (business is null)
            return;
        context.Businesses.Remove(business);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

}
