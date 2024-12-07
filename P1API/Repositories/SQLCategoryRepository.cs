using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;

namespace P1API.Repositories
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLCategoryRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            

            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var existing = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Categories.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var existing = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<Category?> UpdateAsync(int id, Category category)
        {
            var existing = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (existing == null)
            {
                return null;
            }
            existing.CategoryName = category.CategoryName;
            
            existing.ParentCategoryId = category.ParentCategoryId;

            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
