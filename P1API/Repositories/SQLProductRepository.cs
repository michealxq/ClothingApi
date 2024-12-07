using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;

namespace P1API.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLProductRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var existing = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Products.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async  Task<Product?> GetByIdAsync(int id)
        {
            var existing = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existing = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existing == null)
            {
                return null;
            }
            
            existing.ProductName=product.ProductName;
            existing.Description=product.Description;
            existing.Price=product.Price;
            existing.StockQuantity=product.StockQuantity;
            existing.CategoryId=product.CategoryId;

            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
