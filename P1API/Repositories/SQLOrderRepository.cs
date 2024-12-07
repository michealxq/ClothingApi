using Microsoft.EntityFrameworkCore;
using P1API.Data;
using P1API.Models.Domains;

namespace P1API.Repositories
{
    public class SQLOrderRepository:IOrderRepository
    {
        private readonly ClothingDbContext dbContext;

        public SQLOrderRepository(ClothingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var existing = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Orders.Remove(existing);
            dbContext.SaveChanges();
            return existing;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var existing = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (existing == null)
            {
                return null;
            }
            return existing;
        }

        public async Task<Order?> UpdateAsync(int id, Order order)
        {
            var existing = await dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (existing == null)
            {
                return null;
            }
            
            existing.UserId = order.UserId;
            existing.OrderDate = order.OrderDate;
            existing.TotalAmount = order.TotalAmount;
            existing.OrderStatus = order.OrderStatus;

            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
