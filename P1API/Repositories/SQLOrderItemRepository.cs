using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;

namespace P1API.Repositories
{
    public class SQLOrderItemRepository : IOrderItemRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLOrderItemRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<OrderItem> CreateAsync(OrderItem orderItem)
        {
            await dbContext.OrderItems.AddAsync(orderItem);
            await dbContext.SaveChangesAsync();

            return orderItem;
        }

        public async Task<OrderItem?> DeleteAsync(int id)
        {
            var existing = await dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.OrderItems.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            var existing = await dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<OrderItem?> UpdateAsync(int id, OrderItem orderItem)
        {
            var existing = await dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
            if (existing == null)
            {
                return null;
            }
            
            existing.OrderId = orderItem.OrderId;
            existing.ProductId = orderItem.ProductId;
            existing.Quantity = orderItem.Quantity;
            existing.Price  = orderItem.Price;

            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
