using EcoMeal.Database;
using EcoMeal.Database.Entities;
using EcoMeal.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Repositories
{
    public class PackageRepository(EcoMealDbContext context) : IPackageRepository
    {
        public async Task<List<Package>> GetAllAsync()
        {
            // Poți scoate .Include() dacă nu ai definit relația de navigare către Business
            return await context.Packages
                                .Include(p => p.Business)
                                .ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(Guid id)
        {
            return await context.Packages.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Package package)
        {
            await context.Packages.AddAsync(package);
        }

        public async Task DeleteAsync(Guid id)
        {
            var package = await context.Packages.FirstOrDefaultAsync(p => p.Id == id);

            if (package is null)
                return;

            context.Packages.Remove(package);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
